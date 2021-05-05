using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_Traveling : IState
{

    private NPCController controller;
    private readonly GameSceneManager gameSceneManager;
    private readonly WaypointManager waypointManager;
    private NPCMovement npcMovement;
    private Stack<Scenes> scenesPath;


    public NPC_State_Traveling(NPCController controller, GameSceneManager gameSceneManager, WaypointManager waypointManager)
    {
        this.controller = controller;
        this.gameSceneManager = gameSceneManager;
        this.waypointManager = waypointManager;
    }

    public void OnEnter()
    {
        switch (controller.Schedule.CurrentEvent.GetEventType())
        {
            case EventTypes.Work:
                if(controller.EmployeeController.CurrentProject != null)
                {
                    controller.MovementHandler.StartMovement(controller.EmployeeController.CurrentProject.CoordinateLocation, controller.CurrentScene, controller.EmployeeController.CurrentProject.SceneLocation);
                }
                else
                    controller.MovementHandler.StartMovement(new Vector2(-5, 11), controller.CurrentScene, controller.EmployeeController.WorkSpace.Scene);
                break;
            case EventTypes.Lunch:
                controller.MovementHandler.StartMovement(new Vector2(5,12), controller.CurrentScene, Scenes.Bakery);
                break;
            case EventTypes.FreeTime:
                break;
            default:
                break;
        }

    }

    public void OnExit()
    {
        controller.MovementHandler.Stop();
    }

    public void Tick()
    {
        controller.MovementHandler.TraversePath();

    }


   
}
