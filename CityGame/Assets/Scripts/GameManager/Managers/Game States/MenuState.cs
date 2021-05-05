using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IState
{
    private readonly GameManager gameManager;
    private readonly UIController menuController;

    public MenuState(GameManager gameManager, UIController menuController)
    {
        this.gameManager = gameManager;
        this.menuController = menuController;
    }

    public void OnEnter()
    {
        GameManager.instance.GameState = GameState.Menu;
        menuController.CreateCanvas();
    }

    public void OnExit()
    {
        menuController.DestroyCanvas();
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.Resume();
        }
    }

}
