using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_Working : IState
{

    private readonly NPCController npcController;
    private CityProjectTicket projectTicket;
    private ProjectSpaceController projectSpaceController;

    private bool projectSpaceActive;
    

    public NPC_State_Working(NPCController npcController)
    {
        this.npcController = npcController;
    }


    public void OnEnter()
    {

        projectTicket = npcController.EmployeeController.CurrentProject;

        GameSceneManager.instance.OnSceneLoaded += CheckForSceneComponents;

        CheckForSceneComponents(GameSceneManager.instance.GetCurrentScene());

    }

    public void OnExit()
    {
        if (projectSpaceActive)
        {
            Object.Destroy(projectSpaceController.gameObject);
            projectSpaceActive = false;
        }
    }

    public void Tick()
    {
        var percentComplete = projectTicket.AmountOfWorkComplete/projectTicket.CityProjectHolder.CityProject.TimeToComplete;

        if (percentComplete < 1)
        {
            projectTicket.AmountOfWorkComplete += 1f * Time.deltaTime;

            if(projectSpaceActive)
                projectSpaceController.ProgresSlider.value = percentComplete;
        }
        else
        {
            npcController.EmployeeController.RemoveFinishedProject();
            npcController.MovementHandler.SetDestination(npcController.EmployeeController.OfficeLocation, npcController.EmployeeController.WorkSpace.Scene);
        }

        

    }

    public void CheckForSceneComponents(Scenes scene)
    {
        

        if (npcController.CurrentScene == GameSceneManager.instance.GetCurrentScene())
        {
            projectSpaceController = Object.Instantiate(npcController.EmployeeController.CurrentProject.CityProjectSpaceHolder.CityProjectSpace.ProjectSpace, npcController.EmployeeController.CurrentProject.CityProjectSpaceHolder.CityProjectSpace.Location, Quaternion.identity).GetComponent<ProjectSpaceController>();
            projectSpaceActive = true;
        }
        else if(projectSpaceController != null)
        {
            Object.Destroy(projectSpaceController.gameObject);
            projectSpaceActive = false;
            
        }
    }
}
