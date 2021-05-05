using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public enum GameState { Menu, Play, Dialogue}
/// <summary>
/// 1. In "LoadPlaceableObjects", load the information from memory into the data file. 
/// (You can copy and paste the instantiation and the for loop and replace the data 
/// </summary>
public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //My Managers to assist running the game
    [SerializeField] private UIManager uIManager = new UIManager();
    private DialogueManager dialogueManager;

    //Singleton Managers
    PlayerController playerManager;

    //Pause Stuff
    private bool isPaused;

    //Game State Machine
    [SerializeField] [ReadOnly] private GameState gameState;
    private StateMachine _gameStateMachine;

    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Debug.LogWarning("GameManager already exists");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        #endregion

        DialogueManager = GetComponent<DialogueManager>();

    }

    private void Start()
    {
        //Singleton Refrences
        playerManager = PlayerController.instance;

        StartStateMachine();

        StartGameWindowSettings();

    }

    private void Update()
    {
        _gameStateMachine.Tick();

    }

    private void StartStateMachine()
    {
        _gameStateMachine = new StateMachine();

        var menuState = new MenuState(this, uIManager.PauseMenuUI);
        var playState = new PlayState(this, uIManager.InventoryUI, playerManager);
        var dialogueState = new DialogueState(this, uIManager.DialogueUI, dialogueManager);

        At(to: menuState, from: playState, condition: IsGameNotPaused());
        At(to: playState, from: menuState, condition: IsGamePaused());
        At(to: playState, from: dialogueState, condition: EnterDialogue());
        At(to: dialogueState, from: playState, condition: LeaveDialogue());


        _gameStateMachine.SetState(menuState);

        void At(IState to, IState from, Func<bool> condition) => _gameStateMachine.AddTransition(from: to, to: from, condition);

        Func<bool> IsGamePaused() => () => isPaused;
        Func<bool> IsGameNotPaused() => () => !isPaused;
        Func<bool> EnterDialogue() => () => dialogueManager.CurrentDialogueController != null;
        Func<bool> LeaveDialogue() => () => dialogueState.LeaveDialogueState;


    }

    private void StartGameWindowSettings()
    {
        int width = 1920; // or something else
        int height = 1080; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Quit()
    {
        GameSceneManager.instance.QuitToMenu(Scenes.Main_Menu);
    }

    public GameState GameState { get => gameState; set => gameState = value; }
    public bool IsPaused { get => isPaused; set => isPaused = value; }
    public DialogueManager DialogueManager { get => dialogueManager; set => dialogueManager = value; }
 
}


