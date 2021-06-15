using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LibraryProjectTicket :  CityProjectTicket, ICityProjectTicket
{
    [SerializeField]
    private LibraryProjects projectID;
    private LibraryProject project;

    
    [SerializeField]
    private LibraryProjectSpaces projectSpaceID;
    private LibraryProjectSpace projectSpace;

    public LibraryProjectTicket( LibraryProjects projectID, LibraryProjectSpaces projectSpaceID)
    {
        this.projectSpaceID = projectSpaceID;
        this.projectID = projectID;

        SetProject(projectID);
        SetProjectSpace(projectSpaceID);

        
    }

    public void SetProject<T>(T projectID) where T : Enum
    {
        LibraryProjects project = (LibraryProjects)Enum.ToObject(typeof(LibraryProjects), projectID);
        this.project = ScriptableObjectsHolder.instance.cityProjectsHolder.LibraryProjects[project];
        this.projectID = project;
    }

    public void SetProjectSpace<T>(T projectSpaceID) where T : Enum
    {
        LibraryProjectSpaces projectSpace = (LibraryProjectSpaces)Enum.ToObject(typeof(LibraryProjectSpaces), projectSpaceID);
        this.projectSpace = ScriptableObjectsHolder.instance.cityProjectsHolder.LibraryProjectSpaces[projectSpace];
        this.projectSpaceID = projectSpace;
    }

    public Scenes GetDestinationScene()
    {
        return projectSpace.Scene;
    }

    public Vector2 GetDestinationPosition()
    {
        return projectSpace.Location;
    }

    public CityProjectSpace GetCityProjectSpace()
    {
        return projectSpace;
    }

    public CityProject GetCityProject()
    {
        return project;
    }

    [JsonIgnore]
    public LibraryProject Project { get => project; set => project = value; }
    [JsonIgnore]
    public LibraryProjectSpace ProjectSpace { get => projectSpace; set => projectSpace = value; }

    [JsonProperty]
    public LibraryProjects ProjectID { get => projectID; set => projectID = value; }
    [JsonProperty]
    public LibraryProjectSpaces ProjectSpaceID { get => projectSpaceID; set => projectSpaceID = value; }
}

