using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_WaitingForJob : IState
{
    private readonly NPCController controller;
    private readonly EmployeeController employeeController;
    public bool hasJob;
    
    public NPC_State_WaitingForJob(NPCController controller)
    {
        this.controller = controller;
        employeeController = controller.EmployeeController;
    }

    public void OnEnter()
    {
        controller.CurrentState = NPCStates.WaitingOnJob;
        employeeController.WorkSpace.OnProjectQueueUpdated += ProjectQueueUpdated;
        ProjectQueueUpdated();

    }

    public void OnExit()
    {
        employeeController.WorkSpace.OnProjectQueueUpdated -= ProjectQueueUpdated;
    }

    public void Tick()
    {
        //Add wait time

    }

    public void ProjectQueueUpdated()
    {
        hasJob = employeeController.GetJobFromQueue();

        if(hasJob)
        {
            controller.MovementHandler.SetDestination(employeeController.CurrentProject.GetDestinationPosition(), employeeController.CurrentProject.GetDestinationScene());
        
        }
    }
}
