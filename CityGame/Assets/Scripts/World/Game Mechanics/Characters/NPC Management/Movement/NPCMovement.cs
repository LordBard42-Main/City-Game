using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    //This Keeps track of where npc is even if not in scene;
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 coordinateDestination;
    [SerializeField] private Scenes sceneDestination;

    //Path Variables
    private Stack<Vector2> coordinatePath;
    private Stack<Scenes> scenePath;
    private Scenes currentScene;

    //Script Components
    private Pathfinder pathfinder;

    //Gameobject Variables
    private GameObject npcObject;
    private Transform npcTransform;

    //Movement Variables
    [SerializeField] private float walkSpeed = 3.0f;
    private float moveTimeTotal;
    private float moveTimeCurrent;
    private Vector2 nextWaypoint;
    private bool isTraveling = false;

    //Callback to alert npc of current path ending
    public delegate void SceneChangedCallback(Scenes scene);
    public event SceneChangedCallback OnSceneChange;

    private void Start()
    {
        //Script Components
        pathfinder = GetComponent<Pathfinder>();

        npcObject = transform.GetChild(0).gameObject;
        npcTransform = transform.GetChild(0).GetComponent<Transform>();

        position = npcTransform.position;
    }

    public void SetDestination(Vector2 coordinateDestination, Scenes sceneDestination)
    {
        this.coordinateDestination = coordinateDestination;
        this.sceneDestination = sceneDestination;
    }

    public void StartMovement(Scenes currentScene)
    {
        scenePath = pathfinder.GetScenePath(currentScene, sceneDestination);
        UpdateMovement();

    }

    public void UpdateMovement()
    {
        currentScene = scenePath.Pop();
        if (scenePath.Count == 0)
        {
            Debug.Log("Start:" + position + " End: " + coordinateDestination + " Scene: " + currentScene);
            coordinatePath = pathfinder.GetCoordinatePath(position, coordinateDestination, currentScene);
        }
        else
        {
            coordinatePath = pathfinder.GetCoordinatePath(position, scenePath.Peek(), currentScene);
        }

    }

    public void TraversePath()
    {
        if (coordinatePath != null && coordinatePath.Count > 0)
        {
            if (moveTimeCurrent < moveTimeTotal)
            {
                //Lerps NPC
                moveTimeCurrent += Time.deltaTime;
                if (moveTimeCurrent > moveTimeTotal)
                    moveTimeCurrent = moveTimeTotal;
                position = Vector2.Lerp(nextWaypoint, coordinatePath.Peek(), moveTimeCurrent / moveTimeTotal);
            }
            else
            {
                nextWaypoint = coordinatePath.Pop();

                if (coordinatePath.Count == 0)
                {
                    EndReached();

                    //Return to avoid position being set incorrectly;
                    return;
                }
                else
                {
                    //Sets up Lerp to Next waypoint
                    moveTimeCurrent = 0;
                    moveTimeTotal = (nextWaypoint - coordinatePath.Peek()).magnitude / walkSpeed;
                }
            }

            if (npcObject.activeSelf) 
                SetPosition();
        }

    }

    public void SetPosition()
    {
        npcTransform.position = position;
    }

    private void EndReached()
    {
        coordinatePath = null;
        moveTimeTotal = 0;
        moveTimeCurrent = 0;

        if (scenePath.Count == 0)
        {
            coordinateDestination = default(Vector2);
            sceneDestination = default(Scenes);
        }
        else {
            position = pathfinder.GetNodeToScene(scenePath.Peek(), currentScene).location;

            if (OnSceneChange != null)
                OnSceneChange(scenePath.Peek());

            UpdateMovement();
        }


    }

    public void Stop()
    {
        coordinatePath = null;
        moveTimeTotal = 0;
        moveTimeCurrent = 0;

        nextWaypoint = default(Vector2);

    }







    public Vector2 Position { get => position; set => position = value; }
    public bool IsTraveling { get => isTraveling; set => isTraveling = value; }
    public Vector2 CoordinateDestination { get => coordinateDestination; private set => coordinateDestination = value; }
    public Scenes SceneDestination { get => sceneDestination; private set => sceneDestination = value; }
}
