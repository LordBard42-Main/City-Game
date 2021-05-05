using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : IState
{

    private readonly GameManager gameManager;
    private readonly UIController inventoryController;
    private readonly PlayerController playerManager;
    public PlayState(GameManager gameManager, UIController inventoryController, PlayerController playerManager)
    {
        this.gameManager = gameManager;
        this.inventoryController = inventoryController;
        this.playerManager = playerManager;
    }

    public void OnEnter()
    {
        GameManager.instance.GameState = GameState.Play;
        inventoryController.CreateCanvas();
        UnityEngine.Object.DontDestroyOnLoad(inventoryController.GetCreatedCanvas());
        
    }

    public void OnExit()
    {
        inventoryController.DestroyCanvas();
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.Pause();
        } 
        else if(Input.GetKey(KeyCode.Space))
        {
            Tuple<bool, Collider2D> interactInfo = playerManager.PlayerInteraction.GetInteractInfo();
            if (interactInfo.Item1)
            {
                interactInfo.Item2.SendMessageUpwards("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

}
