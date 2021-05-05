using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneStructure
{
    [SerializeField] private SceneNode townSquare;
    [SerializeField] private SceneNode bakery;
    [SerializeField] private SceneNode library;


    public SceneNode GetSceneNode(Scenes scene)
    {

        SceneNode node = null;
        switch (scene)
        {
            case Scenes.None:
                break;
            case Scenes.Town_Square:
                node = townSquare;
                break;
            case Scenes.Bakery:
                node = bakery;
                break;
            case Scenes.Library:
                node = library;
                break;
            case Scenes.Main_Menu:
                break;
            default:
                break;
        }

        return node;
    }

}
