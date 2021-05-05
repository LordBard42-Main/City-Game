using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "sceneWaypoints", menuName = "Pathing Manager/Scene Waypoints")]
public class SceneWaypoints : ScriptableObject
{

    [SerializeField] private WaypointNode[] nodes;


    public WaypointNode FindClosestNode(Vector2 location)
    {
        WaypointNode closestNode = null;
        float closestDistance = -1;

        foreach(WaypointNode node in nodes)
        {
            float distance = (location - node.location).magnitude;

            if(closestDistance == -1)
            {
                closestDistance = distance;
                closestNode = node;
                continue;
            }

            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestNode = node;
            }
        }

        return closestNode;

    }
    public WaypointNode FindNodeToScene(Scenes scene)
    {
        foreach(WaypointNode node in nodes)
        {
            if (scene == node.LeadsTo)
                return node;
        }
        return null;
    }


}
