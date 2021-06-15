using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LibraryProjectSpaceHolder : CityProjectSpaceHolder
{

    [SerializeField]
    [BoxGroup("Static Data")]
    [LabelWidth(100)]
    private LibraryProjectSpace libraryProjectSpace;

    [SerializeField]
    [BoxGroup("Static Data")]
    [LabelWidth(100)]
    [TableList]
    private List<LibraryProjectsHolder> libraryProjects;


    [JsonIgnore]
    public LibraryProjectSpace LibraryProjectSpace { get => libraryProjectSpace;}

    [JsonProperty]
    public List<LibraryProjectsHolder> LibraryProjects { get => libraryProjects; set => libraryProjects = value; }
}
