using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps; 

/// <summary>
/// 1.When Creating a new ite, set the item parent down below;
/// </summary>
public class StoveController : InteractableController
{

    [SerializeField] private Inventory ovenInventory;
    private GameClock gameClock;
    private bool isBakingComplete = true;
    private int bakingFinishTime;

    private void Awake()
    {
        gameClock = GameClock.instance;

    }

    private void OnDestroy()
    {
        if(gameClock != null)
            gameClock.OnHour -= BakeProcess;
    }

    public override void Interact()
    {
        base.Interact();

        
    }

    private void StartBakeProcess()
    {
        isBakingComplete = false;
        bakingFinishTime = gameClock.Hours + 1;
        gameClock.OnHour += BakeProcess;

    }

    private void BakeProcess(TimeStamp currentTime)
    {
        Debug.Log(bakingFinishTime);
        if (gameClock.Hours == bakingFinishTime)
        {
            isBakingComplete = true;
            gameClock.OnHour -= BakeProcess;
        }

    }
    
}
