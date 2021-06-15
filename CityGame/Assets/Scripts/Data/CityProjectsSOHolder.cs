using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;

[CreateAssetMenu(fileName = "CityProjectHolder", menuName = "CityProjectHolder")]
public class CityProjectsSOHolder : SerializedScriptableObject
{
    [SerializeField, OdinSerialize]
    [TabGroup("Library")]
    private Dictionary<LibraryProjects, LibraryProject> libraryProjects;

    [SerializeField, OdinSerialize]
    [TabGroup("Library")]
    private Dictionary<LibraryProjectSpaces, LibraryProjectSpace> libraryProjectSpaces;


    [SerializeField]
    [TabGroup("Construction")]
    private Dictionary<ConstructionProjects, CityProject> constructionProjects;
    

    public Dictionary<LibraryProjects, LibraryProject> LibraryProjects { get => libraryProjects; private set => libraryProjects = value; }
    public Dictionary<LibraryProjectSpaces, LibraryProjectSpace> LibraryProjectSpaces { get => libraryProjectSpaces; private set => libraryProjectSpaces = value; }
    public Dictionary<ConstructionProjects, CityProject> ConstructionProjects { get => constructionProjects; private set => constructionProjects = value; }
}
