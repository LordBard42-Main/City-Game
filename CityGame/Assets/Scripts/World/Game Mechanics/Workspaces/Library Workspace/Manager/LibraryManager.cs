using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

public class LibraryManager : Workspace, IWorkspace
{    
    public static LibraryManager instance;

    private readonly string PATH = "/Workspaces";
    private readonly string FILENAME = "/libraryInformation.JSON";
    private PathAndFileName pathAndFileName;

    [SerializeField] 
    [BoxGroup("Save Information")]
    private LibraryInformation libraryInformation;

    public event IWorkspace.ProjectQueueUpdated OnProjectQueueUpdated;

    protected override void Awake()
    {

        #region Singleton

        if(instance != null)
        {
            Debug.LogWarning("Library Manager Already Exists");
            return;
        }
        instance = this;
        #endregion

        base.Awake();

        pathAndFileName = new PathAndFileName(PATH, FILENAME);
        libraryInformation.DeserializeInformation(pathAndFileName);


    }

    private void Start()
    {
        manager = CharacterManager.instance.GetCharacterConroller(libraryInformation.Head);

        if (manager != null)
            manager.EmployeeController.SetEmploymentStatus(this, Employee_Type.Manager);

        assistant = CharacterManager.instance.GetCharacterConroller(libraryInformation.Assistant);

        if (assistant != null)
            assistant.EmployeeController.SetEmploymentStatus(this, Employee_Type.Assistant);

        CheckForAvailableJobs();

    }

    private void OnDestroy()
    {
        if(instance == this)
            libraryInformation.SerializeInformation(pathAndFileName);
        
    }

    public void CheckForAvailableJobs()
    {
        for (int i = 0; i < LibraryProjectSpaces.Count; i++)
        {
            var librarySpaces= LibraryProjectSpaces[i];
            for (int n = 0; n < librarySpaces.LibraryProjects.Count; n++)
            {
                var libraryProject = librarySpaces.LibraryProjects[n];
                if (libraryProject != null)
                {
                    if(libraryProject.WorkReady)
                    {
                        bool projecInQueue = false; ;
                        foreach(var ticket in ProjectQueue)
                        {
                            if (libraryProject.LibraryProject == ticket.Project)
                            {
                                projecInQueue = true;
                                break; 
                            }
                            
                        }

                        if(projecInQueue)
                        {
                            continue;
                        }
                        else
                        {
                            libraryProject.WorkReady = false;
                            BuildTicket(libraryProject.LibraryProject.Id, librarySpaces.LibraryProjectSpace.SpaceID);
                            
                        }
                    }
                }
            }


        }
    }

    public void BuildTicket<T,S>(T projectID, S projectSpaceID)
    {
        LibraryProjects project = (LibraryProjects)Enum.ToObject(typeof(LibraryProjects),projectID);
        LibraryProjectSpaces projectSpace = (LibraryProjectSpaces)Enum.ToObject(typeof(LibraryProjectSpaces),projectSpaceID);

        ProjectQueue.Add(new LibraryProjectTicket(project , projectSpace));
        
        if(OnProjectQueueUpdated != null)
            OnProjectQueueUpdated.Invoke();

        
    }

    public ICityProjectTicket GetProjectTicket(SkillController skillController)
    {

        for (int i = 0; i < ProjectQueue.Count; i++)
        {
            if (ProjectQueue[i].Project.SkillLevelRequired <= skillController.GetSkill(Skills.LibrarySkill).Level)
            {
                ICityProjectTicket projectTicket = ProjectQueue[i];
                ProjectQueue.RemoveAt(i);
                Debug.Log("Job Added");
                return (projectTicket);
            }
        }


        return default(ICityProjectTicket);
    }

    public Scenes GetSceneLocation()
    {
        return Scenes.Library;
    }

    public List<LibraryProjectSpaceHolder> LibraryProjectSpaces { get => libraryInformation.libraryProjectSpaces; }
    public List<LibraryProjectTicket> ProjectQueue { get => libraryInformation.projectQueue; }

}
