using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ConstructionManager : Workspace
{ 
    public static ConstructionManager instance;


    protected override void Awake()
    {
        #region  Singleton
        if (instance != null)
        {
            Debug.LogWarning("CityManagement already exists");
            return;
        }
        instance = this;
        #endregion

        base.Awake();

        id = Workspace_ID.Construction;

        smallProjects = Resources.FindObjectsOfTypeAll<SmallConstructionProject>().Cast<CityProject>().ToList();
        mediumProjects = Resources.FindObjectsOfTypeAll<MediumConstructionProject>().Cast<CityProject>().ToList();
        largeProjects = Resources.FindObjectsOfTypeAll<LargeConstructionProject>().Cast<CityProject>().ToList();

        Debug.Log("City Manager Start");
    }

    private void Start()
    {
        List<CityProject> projects;

        projects = GetProjectsBySkillLevel(ProjectSize_IDs.All);
        foreach (CityProject project in projects)
        {
            Debug.Log(project.name + (project as ConstructionProject).BuildPrefab);
        }
    }


}

