using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Workspace_ID { None, Library, Construction }
public enum Employee_Type { None, Assistant, Manager }

public abstract class Workspace : MonoBehaviour, IWorkspace
{
    [SerializeField] [ReadOnly] protected Workspace_ID id;
    [SerializeField] private Scenes scene;

    [Header("Serialization")]
    [SerializeField] private PathAndFileName pathAndFileName_WorkspaceInfo;
    [SerializeField] private WorkspaceInformation workspaceInformation;

    
    [Header("Employees")]
    [SerializeField] protected CharacterController manager;
    [SerializeField] protected CharacterController assistant;

    [Header("Finaces")]
    [SerializeField] protected float funds;

    [Header("City Projects")]
    [SerializeField] protected List<CityProject> smallProjects;
    [SerializeField] protected List<CityProject> mediumProjects;
    [SerializeField] protected List<CityProject> largeProjects;

    [Header("City Project Spaces")]
    [SerializeField] protected List<CityProjectSpaceRefrence> cityProjectSpaces;

    [Header("Project Queue")]
    protected List<CityProjectSpaceRefrence> projectQueue = new List<CityProjectSpaceRefrence>();

    //Events
    public delegate void ProjectQueueUpdated();
    public event ProjectQueueUpdated OnProjectQueueUpdated;


    protected virtual void Awake()
    {
        workspaceInformation.DeserializeInformation(pathAndFileName_WorkspaceInfo);

        projectQueue = workspaceInformation.ProjectQueue;

    }
    private void Start()
    {
        InitializeWorkspace();



    }

    private void OnDestroy()
    {
        workspaceInformation.SerializeInformation(pathAndFileName_WorkspaceInfo);
    }


    public List<CityProject> GetObjectsBetweenSkillLevels(ProjectSize_IDs size, int floor, int ceiling)
    {

        List<CityProject> cityProjects = new List<CityProject>();
        List<CityProject> searchProjects = new List<CityProject>();

        searchProjects = GetProjectsToSearch(size, searchProjects);

        foreach (CityProject project in searchProjects)
        {
            if (project.SkillLevelRequired > floor && project.SkillLevelRequired < ceiling)
                cityProjects.Add(project);
        }

        return cityProjects;
    }

    public List<CityProject> GetObjectsOfSkillLevel(ProjectSize_IDs size, int level)
    {
        List<CityProject> cityProjects = new List<CityProject>();
        List<CityProject> searchProjects = new List<CityProject>();

        searchProjects = GetProjectsToSearch(size, searchProjects); 
        
        foreach (CityProject project in searchProjects)
        {
            if (project.SkillLevelRequired == level)
                cityProjects.Add(project);
        }

        return cityProjects;

    }

    public List<CityProject> GetProjectsBySkillLevel(ProjectSize_IDs size)
    {
        List<CityProject> cityProjects = new List<CityProject>();
        List<CityProject> searchProjects = new List<CityProject>();

        searchProjects = GetProjectsToSearch(size, searchProjects);

        foreach(CityProject project in searchProjects)
            cityProjects.Add(project);

        cityProjects.Sort((pX, pY) => pX.SkillLevelRequired.CompareTo(pY.SkillLevelRequired));

        return cityProjects;
    }
    
    private List<CityProject> GetProjectsToSearch(ProjectSize_IDs size, List<CityProject> searchProjects)
    {
        switch (size)
        {
            case ProjectSize_IDs.All:
                break;
            case ProjectSize_IDs.Small:
                searchProjects = smallProjects;
                break;
            case ProjectSize_IDs.Medium:
                searchProjects = mediumProjects;
                break;
            case ProjectSize_IDs.Large:
                searchProjects = largeProjects;
                break;
            default:
                break;
        }

        return searchProjects;
    }

    public void AddCityProjectToQueue(CityProjectSpaceRefrence cityProjectRefrence, CityProject cityProject)
    {
        cityProjectRefrence.CityProject = cityProject;
        projectQueue.Add(cityProjectRefrence);

        if (OnProjectQueueUpdated != null)
            OnProjectQueueUpdated.Invoke();
    }

    public void InitializeWorkspace()
    {

        manager = CharacterManager.instance.GetCharacterConroller(workspaceInformation.Head);
        assistant = CharacterManager.instance.GetCharacterConroller(workspaceInformation.Assistant);

        if (manager != null)
        {
            manager.EmployeeController.SetEmploymentStatus(this, Employee_Type.Manager);
        }
        
        if (assistant != null)
        {
            assistant.EmployeeController.SetEmploymentStatus(this, Employee_Type.Assistant);

        }
        


    }
    public Scenes Scene { get => scene; private set => scene = value; }
    public List<CityProjectSpaceRefrence> ProjectQueue { get => projectQueue; protected set => projectQueue = value; }
}
