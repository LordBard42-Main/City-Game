using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_Working : IState
{

    private readonly NPCController npcController;
    private readonly EmployeeController employeeController;
    private ICityProjectTicket projectTicket;
    private CityProjectSpace cityProjectSpace;
    private ProjectSpaceController projectSpaceController;

    

    public NPC_State_Working(NPCController npcController)
    {
        this.npcController = npcController;
        employeeController = npcController.EmployeeController;
        }


    public void OnEnter()
    {
        npcController.CurrentState = NPCStates.Working;
        projectTicket = employeeController.CurrentProject;
        GameSceneManager.instance.OnSceneLoaded += ManageProjectSpace;

        ManageProjectSpace(GameSceneManager.instance.GetCurrentScene());
       
    }

    public void OnExit()
    {
        GameSceneManager.instance.OnSceneLoaded -= ManageProjectSpace;
    }

    public void Tick()
    {
        var percentComplete = (projectTicket as CityProjectTicket).Progress / projectTicket.GetCityProject().TimeToComplete;

        if (percentComplete < 1)
        {
            (projectTicket as CityProjectTicket).Progress += 1f * Time.deltaTime;

            if(projectSpaceController != null)
                projectSpaceController.ProgresSlider.value = percentComplete;
        }
        else
        {
            npcController.EmployeeController.HasATicket = false;
            npcController.EmployeeController.CurrentProject = null;
            npcController.MovementHandler.SetDestination(new Vector2(-3, 13.5f), npcController.EmployeeController.WorkSpace.GetSceneLocation());

            if (projectSpaceController != null)
                Object.Destroy(projectSpaceController.gameObject);
        }



    }

    public void ManageProjectSpace(Scenes scene)
    {
        if (scene == npcController.CurrentScene && projectSpaceController == null)
            projectSpaceController = Object.Instantiate(projectTicket.GetCityProjectSpace().ProjectSpace.transform, position: projectTicket.GetCityProjectSpace().Location, Quaternion.identity).GetComponent<ProjectSpaceController>();

        else if (scene != npcController.CurrentScene && projectSpaceController != null)
            Object.Destroy(projectSpaceController.gameObject);


    }
}
