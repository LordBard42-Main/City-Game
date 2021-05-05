using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : Interactable
{
    GameSceneManager gameSceneManager;

    public Door door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.Open(gameSceneManager);
        }
    } 

    private void Start()
    {
        gameSceneManager = GameSceneManager.instance;
        gameObject.name = door.Name.ToString();
    }
    public override void Interact()
    {
        base.Interact();
        if(door.isInteractable)
            OpenDoor();
    }

    private void OpenDoor()
    {
        door.Open(gameSceneManager);
    }
}
