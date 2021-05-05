using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour

{
    public static WaypointManager instance;

    [SerializeField] private SceneWaypoints libraryWaypoints;
    [SerializeField] private SceneWaypoints bakeryWaypoints;
    [SerializeField] private SceneWaypoints townSquareWaypoints;

    [SerializeField] private SceneStructure sceneStructure;

    public SceneWaypoints LibraryWaypoints { get => libraryWaypoints; set => libraryWaypoints = value; }
    public SceneWaypoints BakeryWaypoints { get => bakeryWaypoints; set => bakeryWaypoints = value; }
    public SceneWaypoints TownSquareWaypoints { get => townSquareWaypoints; set => townSquareWaypoints = value; }
    public SceneStructure SceneStructure { get => sceneStructure; set => sceneStructure = value; }

    private void Awake()
    {
        #region Singleton

        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;


        #endregion


    }


    public SceneWaypoints GetWaypointsByScene(Scenes scene)
    {
        SceneWaypoints waypoints = null;
        //Debug.Log(scene);
        switch (scene)
        {
            case Scenes.None:
                break;
            case Scenes.Town_Square:
                waypoints = townSquareWaypoints;
                break;
            case Scenes.Bakery:
                waypoints = bakeryWaypoints;
                break;
            case Scenes.Library:
                waypoints = libraryWaypoints;
                break;
            case Scenes.Main_Menu:
                break;
            default:
                break;
        }
        return waypoints;
    }


}
