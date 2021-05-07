using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmployeeController : MonoBehaviour
{
    [SerializeField] private bool isEmployed;

    [SerializeField] private Workspace workspace;
    [SerializeField] private Employee_Type employeeType;
   
    //Primary Components
    private SkillController skillController;


    [SerializeField] CityProjectSpaceRefrence currentProject;

    private void Awake()
    {
        skillController = GetComponent<SkillController>();
    }

    public void SetEmploymentStatus(Workspace workspace, Employee_Type employeeType)
    {
        isEmployed = true;
        this.workspace = workspace;
        this.employeeType = employeeType;
    }

    public bool GetNewProject()
    {
        foreach (CityProjectSpaceRefrence projectReference in workspace.ProjectQueue)
        {
            if (projectReference.CityProject.SkillLevelRequired <= skillController.GetSkill(Skills.LibrarySkill).Level)
            {
                Debug.Log("Project Set");
                currentProject = projectReference;
                return true;
            }
        }
        Debug.Log("Project Not Set");
        return false;
    }


    public void Copy(EmployeeController employmentStatus)
    {
        isEmployed = employmentStatus.isEmployed;
        workspace = employmentStatus.workspace;
        employeeType = employmentStatus.employeeType;
    }

    public Workspace WorkSpace { get => workspace; set => workspace = value; }
    public Employee_Type EmployeeType { get => employeeType; set => employeeType = value; }
    public bool IsEmployed { get => isEmployed; set => isEmployed = value; }
    public CityProjectSpaceRefrence CurrentProject { get => currentProject; set => currentProject = value; }
}
