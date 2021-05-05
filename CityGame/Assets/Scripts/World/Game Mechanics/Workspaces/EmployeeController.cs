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


    [SerializeField] CityProject currentProject;

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

    public void GetNewProject()
    {
        foreach (CityProject project in workspace.ProjectQueue)
        {
            if (project.SkillLevelRequired <= skillController.GetSkill(Skills.LibrarySkill).Level)
            {
                CurrentProject = project;
                return;
            }
        }
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
    public CityProject CurrentProject { get => currentProject; set => currentProject = value; }
}
