using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_WaitingForJob : IState
{
    private readonly NPCController controller;
    private readonly EmployeeController employeeController;
    
    public NPC_State_WaitingForJob(NPCController controller)
    {
        this.controller = controller;
        employeeController = controller.EmployeeController;
    }

    public void OnEnter()
    {
        Debug.Log("Enter waitng state State");

        employeeController.GetNewProject();
        employeeController.WorkSpace.OnProjectQueueUpdated += ProjectQueueUpdated;

    }

    public void OnExit()
    {
        employeeController.WorkSpace.OnProjectQueueUpdated -= ProjectQueueUpdated;
    }

    public void Tick()
    {

    }

    public void ProjectQueueUpdated()
    {
        if (employeeController.CurrentProject == null)
        {
            employeeController.GetNewProject();
            controller.MovementHandler.IsTraveling = true;
            
        }
    }
}
