using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : IState
{
    private readonly GameManager gameManager;
    private readonly UIController uiController;
    private DialogueManager dialogueManager;

    private bool leaveDialogueState;

    public DialogueState(GameManager gameManager, UIController uiController, DialogueManager dialogueManager)
    {
        this.gameManager = gameManager;
        this.uiController = uiController;
        this.dialogueManager = dialogueManager;
    }


    public void OnEnter()
    {
        LeaveDialogueState = false;

        GameManager.instance.GameState = GameState.Dialogue;
        gameManager.Pause();
        uiController.CreateCanvas();
    }

    public void OnExit()
    {
        uiController.DestroyCanvas();
        gameManager.Resume();
        LeaveDialogueState = false;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.CloseDialogue();
            LeaveDialogueState = true;
        }
    }



    public bool LeaveDialogueState { get => leaveDialogueState; set => leaveDialogueState = value; }
}
