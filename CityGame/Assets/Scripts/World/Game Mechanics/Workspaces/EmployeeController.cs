using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmployeeController : MonoBehaviour
{


    [Header("Serialization")]
    [SerializeField] protected PathAndFileName pathAndFileName_EmployeeInfo;
    [SerializeField] protected EmployeeInformation employeeInformation;

    [SerializeField] private bool isEmployed;

   
    //Primary Components
    private SkillController skillController;



    private void Awake()
    {
        skillController = GetComponent<SkillController>();
        employeeInformation.DeserializeInformation(pathAndFileName_EmployeeInfo);
    }

    private void OnDestroy()
    {
        employeeInformation.SerializeInformation(pathAndFileName_EmployeeInfo);
    }

    public void SetEmploymentStatus(IWorkspace workspace, Employee_Type employeeType)
    {
        isEmployed = true;
        this.WorkSpace = workspace;
        this.EmployeeType = employeeType;
    }

    public void AddJobsToQueue()
    {
        WorkSpace.CheckForAvailableJobs();
    }

    public bool GetJobFromQueue()
    {
        CurrentProject = WorkSpace.GetProjectTicket(skillController);

        if (CurrentProject != null)
            HasATicket = true;
        else
            HasATicket = false;

        return CurrentProject != null;
    }

    public IWorkspace WorkSpace { get => employeeInformation.workspace; set => employeeInformation.workspace = value; }
    public ICityProjectTicket CurrentProject { get => employeeInformation.currentProject; set => employeeInformation.currentProject = value; }
    public Employee_Type EmployeeType { get => employeeInformation.employee_Type; set => employeeInformation.employee_Type = value; }
    public bool IsEmployed { get => isEmployed; set => isEmployed = value; }
    public bool HasATicket { get => employeeInformation.hasATicket; set => employeeInformation.hasATicket = value; }
}
