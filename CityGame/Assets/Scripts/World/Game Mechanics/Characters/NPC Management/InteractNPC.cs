using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC : Interactable
{

    private NPCController npcController;

    private void Start()
    {
        if (transform.parent.TryGetComponent<NPCController>(out NPCController controller))
            npcController = controller;
    }

    public override void Interact()
    {
        base.Interact();

        npcController.Interact();
        
    }

}
