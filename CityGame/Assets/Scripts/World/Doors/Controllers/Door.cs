using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Doors { BakeryDoor_Street, BakeryDoor_Store, LibraryDoor_Street, LibraryDoor_Store, None}

[CreateAssetMenu(fileName ="NewDoor", menuName = "Building Assets/Door")]
public class Door : ScriptableObject
{
    new private Doors name;
    public Scenes DestinationScene;
    public Doors DestinationObject;
    public bool isInteractable;
    public bool isLocked;

    public Doors Name { get => name; private set => name = value; }

    public virtual void Open(GameSceneManager gameSceneManager)
    {
        //Will Open Door
        //Debug.Log("Opened: " + name);
        gameSceneManager.LoadScene(DestinationScene, DestinationObject);
    }


}
