using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    //Singletons
    WaypointManager waypointManager;


    private void Start()
    {
        waypointManager = WaypointManager.instance;
    }

    /// <summary>
    /// Finds node closest to given coordniates
    /// </summary>
    /// <param name="startingPoint"></param>
    /// <param name="destination"></param>
    public Stack<Vector2> GetCoordinatePath(Vector2 startVector, Vector2 destinationVector, Scenes currentScene)
    {

        SceneWaypoints sceneWaypoints = waypointManager.GetWaypointsByScene(currentScene);

        WaypointNodeWrapper currentNode = new WaypointNodeWrapper(sceneWaypoints.FindClosestNode(startVector));
        WaypointNodeWrapper endNode = new WaypointNodeWrapper(sceneWaypoints.FindClosestNode(destinationVector));

        return CalculateCoordinatePath(startVector, ref currentNode, endNode);

    }
    
    /// <summary>
    /// Finds node that leads to next scene
    /// </summary>
    /// <param name="startingPoint"></param>
    /// <param name="destination"></param>
    public Stack<Vector2> GetCoordinatePath(Vector2 startVector, Scenes destinationScene, Scenes currentScene)
    {
        SceneWaypoints sceneWaypoints = waypointManager.GetWaypointsByScene(currentScene);
        

        WaypointNodeWrapper currentNode = new WaypointNodeWrapper(sceneWaypoints.FindClosestNode(startVector));
        WaypointNodeWrapper endNode = new WaypointNodeWrapper(sceneWaypoints.FindNodeToScene(destinationScene));

        return CalculateCoordinatePath(startVector, ref currentNode, endNode);

    } 
    
    /// <summary>
    /// Finds node that leads from next scene
    /// </summary>
    /// <param name="startingPoint"></param>
    /// <param name="destination"></param>
    public Stack<Vector2> GetCoordinatePath(Scenes fromScene, Vector2 destinationVector, Scenes currentScene)
    {

        SceneWaypoints sceneWaypoints = waypointManager.GetWaypointsByScene(currentScene);

        WaypointNodeWrapper currentNode = new WaypointNodeWrapper(sceneWaypoints.FindNodeToScene(fromScene));
        WaypointNodeWrapper endNode = new WaypointNodeWrapper(sceneWaypoints.FindClosestNode(destinationVector));

        return CalculateCoordinatePath(currentNode.currentNode.location, ref currentNode, endNode);

    }

    private Stack<Vector2> CalculateCoordinatePath(Vector2 startVector, ref WaypointNodeWrapper currentNode, WaypointNodeWrapper endNode)
    {
        Stack<Vector2> path = new Stack<Vector2>();

        SortedList<float, WaypointNodeWrapper> openList = new SortedList<float, WaypointNodeWrapper>();
        List<WaypointNode> closedList = new List<WaypointNode>();

        openList.Add(0f, currentNode);
        currentNode.previousNode = null;
        currentNode.distance = 0;

        while (openList.Count > 0)
        {
            currentNode = openList.Values[0];
            openList.RemoveAt(0);
            var dist = currentNode.distance;
            //Debug.Log(dist + "::::::::::::");
            closedList.Add(currentNode.currentNode);

            if (currentNode.currentNode == endNode.currentNode)
                break;

            foreach (WaypointNodeWrapper neighbor in currentNode.currentNode.Neighbors)
            {

                if (closedList.Contains(neighbor.currentNode) || openList.ContainsValue(neighbor))
                    continue;

                neighbor.previousNode = currentNode;
                neighbor.distance = dist + (neighbor.currentNode.location - currentNode.currentNode.location).magnitude;
                var distanceToTarget = (neighbor.currentNode.location - endNode.currentNode.location).magnitude;

                //Debug.Log(neighbor.currentNode.name + ": " + neighbor.distance + distanceToTarget);

                //Avoiding Errors in open list with the same key
                if (openList.ContainsKey(neighbor.distance + distanceToTarget))
                    if (openList[neighbor.distance + distanceToTarget].distance < neighbor.distance)
                        continue;
                    else
                        openList[neighbor.distance + distanceToTarget] = neighbor;
                else
                    openList.Add(neighbor.distance + distanceToTarget, neighbor);




            }

            //Debug.Log("Reached end of while");

        }

        if (currentNode.currentNode == endNode.currentNode)
        {
            while (currentNode.previousNode != null)
            {
                path.Push(currentNode.currentNode.location);
                currentNode = currentNode.previousNode;
            }

            //Avoiding doubling back
            var secondToLastVector = path.Peek();

            path.Push(currentNode.currentNode.location);

            //Debug.Log((path.Peek().x == secondToLastVector.x || path.Peek().y == secondToLastVector.y));

            if((startVector.x == path.Peek().x && startVector.x == secondToLastVector.x) || (startVector.y == path.Peek().y && startVector.y == secondToLastVector.y))
                if ((startVector - path.Peek()).magnitude < (startVector - secondToLastVector).magnitude)
                    path.Pop();

            path.Push(startVector);

        }

        return path;
    }

    public Stack<Scenes> GetScenePath(Scenes startScene, Scenes endScene)
    {
        Stack<Scenes> path = new Stack<Scenes>();

        SceneNodeWrapper currentNode = new SceneNodeWrapper(waypointManager.SceneStructure.GetSceneNode(startScene));
        SceneNodeWrapper endNode = new SceneNodeWrapper(waypointManager.SceneStructure.GetSceneNode(endScene));
        Queue<SceneNodeWrapper> openList = new Queue<SceneNodeWrapper>();
        List<SceneNode> closedList = new List<SceneNode>();

        openList.Enqueue(currentNode);

        while (openList.Count > 0)
        {
            currentNode = openList.Dequeue();
            closedList.Add(currentNode.currentNode);

            if (currentNode.currentNode == endNode.currentNode)
                break;

            foreach (SceneNodeWrapper neighbor in currentNode.currentNode.Neighbors)
            {
                if (closedList.Contains(neighbor.currentNode) || openList.Contains(neighbor))
                    continue;

                neighbor.previousNode = currentNode;
                openList.Enqueue(neighbor);
            }


        }

        if (currentNode.currentNode == endNode.currentNode)
        {
            while (currentNode.previousNode != null)
            {
                //Debug.Log(currentNode.currentNode.Scene);
                path.Push(currentNode.currentNode.Scene);
                currentNode = currentNode.previousNode;
            }
            path.Push(currentNode.currentNode.Scene);
        }
        return path;
    }

    public WaypointNode GetNodeToScene(Scenes scene, Scenes fromScene)
    {
        return waypointManager.GetWaypointsByScene(scene).FindNodeToScene(fromScene);

    }
}
