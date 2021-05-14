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
        if (!employeeController.HasProject)
        {
            var wasUpdated = employeeController.GetNewProject();

            if(wasUpdated)
            {
                controller.MovementHandler.SetDestination(employeeController.CurrentProject.CityProjectSpaceHolder.CityProjectSpace.Location, 
                    employeeController.CurrentProject.CityProjectSpaceHolder.CityProjectSpace.Scene);

            }
            
        }
    }
}
