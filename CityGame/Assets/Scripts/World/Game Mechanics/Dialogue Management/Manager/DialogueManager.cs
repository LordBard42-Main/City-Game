using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private bool inDialogue;
    [SerializeField] private DialogueController currentDialogueController;

    public void SetDialogue(DialogueController dialogueController)
    {
        CurrentDialogueController = dialogueController;
        inDialogue = true;
    }

    public void CloseDialogue()
    {
        CurrentDialogueController.EndOfDialogueReached = true;
        CurrentDialogueController = null;
        inDialogue = false;
    }


    public bool InDialogue { get => inDialogue; private set => inDialogue = value; }
    public DialogueController CurrentDialogueController { get => currentDialogueController; private set => currentDialogueController = value; }
}
