using System.Collections;
using UnityEngine;

public class NPC_State_Loitering : IState
{
    public void OnEnter()
    {
        Debug.Log("Entering Loitering");
    }

    public void OnExit()
    {
    }

    public void Tick()
    {
    }
}
