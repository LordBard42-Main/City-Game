using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public enum Scenes { None, Town_Square, Bakery, Library, Main_Menu}

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    
    [SerializeField] private GameObject SceneSwitchCover;
    [SerializeField] private AnimationCurve sceneFade;

    public delegate void SceneLoadedCallback(Scenes scene);
    public event SceneLoadedCallback OnSceneLoaded;

        
    private void Awake()
    {

    #region  Singleton
        if (instance != null)
        {
            Debug.LogWarning("GameSceneManager already exists");
            Destroy(gameObject);
            return;
        }
        instance = this;
    #endregion


    }
    public void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    
    void OnEnable()
    {
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    public void LoadScene(Scenes to, Doors location)
    {
        SceneManager.LoadScene(to.ToString());
        SetWorldBasedOnDoor(location);
    }

    /// <summary>
    /// This gets called automatically whenever unity loads a new scene.
    /// In this instance, it gets called after the screen fades to black
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (OnSceneLoaded != null)
            OnSceneLoaded(GetCurrentScene());
    }

    /// <summary>
    /// Called when quitting to menu
    /// </summary>
    /// <param name="DestinationScene"></param>
    public void QuitToMenu(Scenes DestinationScene)
    {

    }
    
    /// <summary>
    /// Returns the enum equivelant of the current scene
    /// </summary>
    /// <returns></returns>
    public Scenes GetCurrentScene()
    {
        return ((Scenes)System.Enum.Parse(typeof(Scenes), SceneManager.GetActiveScene().name));
    }


    /// <summary>
    /// When entering a scene, change setting if it applies
    /// EX: Outdoor effects vs Indoor effects
    /// </summary>
    /// <param name="scene"></param>
    void ActionBasedOnScene(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.Town_Square:
                break;
            case Scenes.Bakery:
                break;
            case Scenes.Library:
                break;
            case Scenes.Main_Menu:
                break;


        }

    }

    /// <summary>
    /// Teleports player to the correct door location in the next scene
    /// </summary>
    /// <param name="DestinationObject"></param>
    private void SetWorldBasedOnDoor(Doors DestinationObject)
    {

        Vector2 coords = new Vector2();

        switch (DestinationObject)
        {
            case Doors.BakeryDoor_Street:

                coords = new Vector2(13f, 18f);
                break;

            case Doors.BakeryDoor_Store:

                coords = new Vector2(0f, 2f);
                break;
            case Doors.LibraryDoor_Street:

                coords = new Vector2(19.1f, 18f);
                break;

            case Doors.LibraryDoor_Store:

                coords = new Vector2(0f, 2f);
                Debug.Log(coords.ToString());
                break;

            default:
                break;

        }

        PlayerController.instance.PlayerMovement.SetRbPosition(coords);
    }

}