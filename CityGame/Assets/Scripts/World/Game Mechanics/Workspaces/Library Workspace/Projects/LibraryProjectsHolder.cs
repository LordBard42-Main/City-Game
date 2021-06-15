using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LibraryProjectsHolder : CityProjectHolder
{

    [SerializeField]
    [BoxGroup("Static Data")]
    [LabelWidth(100)]
    private LibraryProject libraryProject;

    [JsonIgnore]
    public LibraryProject LibraryProject { get => libraryProject; }
}
