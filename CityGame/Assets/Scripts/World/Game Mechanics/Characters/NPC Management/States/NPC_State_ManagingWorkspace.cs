using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_ManagingWorkspace : IState
{

    private readonly NPCController npcController;
    private readonly Workspace workspace;
 
    

    public NPC_State_ManagingWorkspace(NPCController npcController)
    {
        this.npcController = npcController;
        workspace = npcController.EmployeeController.WorkSpace;
    }

    /// <summary>
    /// I want manager to only check to add projects on entering managing state
    /// </summary>
    public void OnEnter()
    {
        Debug.Log("Entering Managing Workspsace State");
        var projectQueueLength = workspace.ProjectQueue.Count;

        if(projectQueueLength < 5)
        {
            

        }

    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        
    }

}
