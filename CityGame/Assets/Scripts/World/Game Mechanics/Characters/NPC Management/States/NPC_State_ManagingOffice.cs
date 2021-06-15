using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_ManagingOffice : IState
{

    private NPCController npcController;
    private EmployeeController employeeController;
    

    public NPC_State_ManagingOffice(NPCController npcController)
    {
        this.npcController = npcController;

        employeeController = npcController.EmployeeController;
    }

    public void OnEnter()
    {
        employeeController.AddJobsToQueue(); ;
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }

   
}
