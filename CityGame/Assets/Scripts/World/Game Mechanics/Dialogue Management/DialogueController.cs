using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I want to handle all the data handling of Dialogue in here,
/// then Dialogue Manager will display what is needed on screen
/// </summary>
public class DialogueController : MonoBehaviour
{

    private bool talkTo;
    private bool willTalk = true;
    private bool endOfDialogueReached;


    public bool AttemptDialogue()
    {
        if (talkTo)
        {
            talkTo = false;
            return (willTalk);
        }
        else
            return false;

    }

    public bool TalkTo { get => talkTo; set => talkTo = value; }
    public bool EndOfDialogueReached { get => endOfDialogueReached; set => endOfDialogueReached = value; }
}
