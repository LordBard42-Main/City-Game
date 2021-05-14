using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmployeeController : MonoBehaviour
{
    [SerializeField] private bool isEmployed;
    [SerializeField] private bool hasProject;

    [Header("Workspace Information")]
    [SerializeField] private Workspace workspace;
    [SerializeField] private Employee_Type employeeType;
    [SerializeField] private Vector2 officeLocation;

    //Primary Components
    private SkillController skillController;


    [SerializeField] CityProjectTicket currentProject;

    private void Awake()
    {
        skillController = GetComponent<SkillController>();
    }

    public void SetEmploymentStatus(Workspace workspace, Employee_Type employeeType, Vector2 officeLocation)
    {
        isEmployed = true;
        this.workspace = workspace;
        this.employeeType = employeeType;
        this.officeLocation = officeLocation;
    }

    public bool GetNewProject()
    {
        foreach (CityProjectTicket projectTicket in workspace.ProjectQueue)
        {
            if (projectTicket.CityProjectHolder.CityProject.SkillLevelRequired <= skillController.GetSkill(Skills.LibrarySkill).Level)
            {
                Debug.Log("Project Set");
                currentProject = projectTicket;
                workspace.ProjectQueue.Remove(currentProject);
                hasProject = true;
                return true;
            }
        }


        Debug.Log("Project Not Set");
        return false;
    }

    public void RemoveFinishedProject()
    {
        currentProject.CityProjectSpaceHolder.CityProjectSpace.IsBeingWorkedOn = false;
        currentProject.CityProjectHolder.NeedsWorked = false;
        currentProject = null;
        hasProject = false;

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
    public CityProjectTicket CurrentProject { get => currentProject; set => currentProject = value; }
    public bool HasProject { get => hasProject; private set => hasProject = value; }
    public Vector2 OfficeLocation { get => officeLocation; private set => officeLocation = value; }
}
