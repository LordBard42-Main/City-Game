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
        controller.MovementHandler.StartMovement(controller.CurrentScene);
        controller.MovementHandler.IsTraveling = true; 

    }

    public void OnExit()
    {
        controller.MovementHandler.Stop();
        controller.MovementHandler.IsTraveling = false;
    }

    public void Tick()
    {
        controller.MovementHandler.TraversePath();

    }


   
}
