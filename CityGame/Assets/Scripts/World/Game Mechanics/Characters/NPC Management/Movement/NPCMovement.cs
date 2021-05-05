using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    //This Keeps track of where npc is even if not in scene;
    [SerializeField] private Vector2 position;

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
    private Vector2 endPosition;
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


    public void StartMovement(Vector2 destination, Scenes startScene, Scenes endScene)
    {
        endPosition = destination;
        scenePath = pathfinder.GetScenePath(startScene, endScene);
        UpdateMovement();

    }

    public void UpdateMovement()
    {
        currentScene = scenePath.Pop();
;
        if (scenePath.Count == 0)
        {
            coordinatePath = pathfinder.GetCoordinatePath(position, endPosition, currentScene);
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
            //End Path Stuff
            IsTraveling = false;
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
        nextWaypoint = default(Vector2);
        moveTimeTotal = 0;
        moveTimeCurrent = 0;
        isTraveling = false;

    }







    public Vector2 Position { get => position; set => position = value; }
    public bool IsTraveling { get => isTraveling; set => isTraveling = value; }
}
