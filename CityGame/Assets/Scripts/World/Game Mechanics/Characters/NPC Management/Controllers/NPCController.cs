using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCController : CharacterController
{


    //Foreign Components
    private GameSceneManager gameSceneManager;
    private WaypointManager waypointManager;
    private DialogueManager dialogueManager;
    private GameManager gameManager;

    //Primary Components
    private Pathfinder pathfinder;
    private Schedule schedule;
    private NPCMovement movement;
    private DialogueController dialogueController;
    private GameObject npcObject; 

    //State Machine
    private StateMachine stateMachine;


   
    

    protected override void Awake()
    {
        pathfinder = GetComponent<Pathfinder>();
        schedule = GetComponent<Schedule>();
        movement = GetComponent<NPCMovement>();
        dialogueController = GetComponent<DialogueController>();

        base.Awake();
    }

    private void Start()
    {
        StartForeignComponents();

        StartStateMachine();

        StartEvents();

        //Temp Setters
        currentScene = gameSceneManager.GetCurrentScene();


    }
    private void OnDestroy()
    {
        characterInformation.SerializeInformation(pathAndFileName_CharacterInfo);
        movement.OnSceneChange -= UpdateCurrentScene;
        gameSceneManager.OnSceneLoaded -= UpdateActiveStatus;
    }



    private void Update()
    {
        stateMachine.Tick();
    }

    public void CheckSchedule(TimeStamp currentTime)
    {
        bool wasUpdated = Schedule.UpdateCurrentEvent(currentTime);

        if(wasUpdated)
        {
            movement.IsTraveling = true;
        }

        
    }

    public void UpdateCurrentScene(Scenes scene)
    {
        currentScene = scene;

        //Sets NPC Object active status based on scene
        npcObject.SetActive(currentScene == gameSceneManager.GetCurrentScene()); 

    }


    public void UpdateActiveStatus(Scenes scene)
    {
        npcObject.SetActive(currentScene == scene);
        movement.SetPosition();
    }

    
    public void Interact()
    {
        Talk();
    }

    void Talk()
    {
        dialogueController.TalkTo = true;
        //TalkToNPCEventually
    }

    private void StartForeignComponents()
    {
        npcObject = transform.GetChild(0).gameObject;
        gameSceneManager = GameSceneManager.instance;
        waypointManager = WaypointManager.instance;
        gameManager = GameManager.instance;
        dialogueManager = gameManager.DialogueManager;

    }

    private void StartStateMachine()
    {
        stateMachine = new StateMachine();

        //Generic States
        var talkingState = new NPC_State_Talking(dialogueController, dialogueManager);
        var travelingState = new NPC_State_Traveling(this, gameSceneManager, waypointManager);
        var loiteringState = new NPC_State_Loitering();
        var pauseState = new NPC_State_Pause(this);

        //Job States
        var waitingOnJobState = new NPC_State_WaitingForJob(this);
        var workingState = new NPC_State_Working();

        //Transitiotion involving job
        At(to: travelingState, from: waitingOnJobState, condition: IsWaitingOnJob());
        At(to: waitingOnJobState, from: travelingState, condition: FoundJob());

        At(to: loiteringState, from: travelingState, condition: NewEventStarted());
        At(to: travelingState, from: loiteringState, condition: DestinationReached());

        At(to: travelingState, from: talkingState, condition: StartDialogue());
        At(to: loiteringState, from: talkingState, condition: StartDialogue());

        At(to: talkingState, from: pauseState, condition: StartPause());

        At(to: pauseState, from: travelingState, condition: EndPause());
        At(to: pauseState, from: loiteringState, condition: EndPause());

        void At(IState to, IState from, Func<bool> condition) => stateMachine.AddTransition(to, from, condition);

        Func<bool> NewEventStarted() => () => movement.IsTraveling;
        Func<bool> DestinationReached() => () => !movement.IsTraveling;
        Func<bool> StartDialogue() => () => dialogueController.AttemptDialogue();
        Func<bool> StartPause() => () => talkingState.ReachedDialogueEnd;
        Func<bool> EndPause() => () => pauseState.CurrentTime >= pauseState.WAITTIME;
        Func<bool> IsWaitingOnJob() => () => employeeController.IsEmployed && !movement.IsTraveling 
                                            && currentScene == EmployeeController.WorkSpace.Scene && employeeController.CurrentProject == null;
        Func<bool> FoundJob() => () => employeeController.IsEmployed && !movement.IsTraveling && employeeController.CurrentProject != null;

        stateMachine.SetState(loiteringState);
    }

    private void StartEvents()
    {
        movement.OnSceneChange += UpdateCurrentScene;
        gameSceneManager.OnSceneLoaded += UpdateActiveStatus;
    }



    public Schedule Schedule { get => schedule; private set => schedule = value; }
    public NPCMovement MovementHandler { get => movement; private set => movement = value; }
    public DialogueController DialogueController { get => dialogueController; private set => dialogueController = value; }
    public Scenes CurrentScene { get => currentScene; private set => currentScene = value; }
}
