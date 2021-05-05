using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_Pause : IState
{
    private NPCController controller;

    private float currentTime;
    private float _WAITTIME = 3;

    public NPC_State_Pause(NPCController controller)
    {
        this.controller = controller;

    }

    public void OnEnter()
    {
        currentTime = 0;
    }

    public void OnExit()
    {
    }

    public void Tick()
    {
        currentTime += Time.deltaTime;
    }

    public float CurrentTime { get => currentTime; set => currentTime = value; }
    public float WAITTIME { get => _WAITTIME; set => _WAITTIME = value; }
}
