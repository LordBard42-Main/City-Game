using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_Working : IState
{

    private readonly NPCController npcController;
    private CityProjectSpaceRefrence projectSpaceRefrence;
    private ProjectSpaceController projectSpaceController;

    

    public NPC_State_Working(NPCController npcController)
    {
        this.npcController = npcController;
    }


    public void OnEnter()
    {
        Debug.Log(npcController.EmployeeController.CurrentProject.CityProject);
        projectSpaceRefrence = npcController.EmployeeController.CurrentProject;
        projectSpaceController = Object.Instantiate(npcController.EmployeeController.CurrentProject.ProjectSpace, npcController.EmployeeController.CurrentProject.Location, Quaternion.identity).GetComponent<ProjectSpaceController>();
        

    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        var percentComplete = projectSpaceRefrence.AmountOfWorkComplete/projectSpaceRefrence.CityProject.TimeToComplete;

        if (percentComplete < 1)
        {
            projectSpaceRefrence.AmountOfWorkComplete += 1f * Time.deltaTime;
            projectSpaceController.ProgresSlider.value = percentComplete;
        }
        else
        {
            npcController.EmployeeController.CurrentProject = null;
            npcController.MovementHandler.SetDestination(new Vector2(-3, 13.5f), npcController.EmployeeController.WorkSpace.Scene);
        }

        

    }
}
