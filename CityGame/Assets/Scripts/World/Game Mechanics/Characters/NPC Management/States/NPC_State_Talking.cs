using System.Collections;
using UnityEngine;

public class NPC_State_Talking : IState
{

    private DialogueController dialogueController;
    DialogueManager dialogueManager;

    private bool inDialogue;
    private bool reachedDialogueEnd = false;


    public NPC_State_Talking(DialogueController dialogueController, DialogueManager dialogueManager)
    {
        this.dialogueController = dialogueController;
        this.dialogueManager = dialogueManager;
    }


    public void OnEnter()
    {
        dialogueManager.SetDialogue(dialogueController);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        reachedDialogueEnd = !dialogueManager.InDialogue;
    }

    public bool ReachedDialogueEnd { get => reachedDialogueEnd; set => reachedDialogueEnd = value; }
}
