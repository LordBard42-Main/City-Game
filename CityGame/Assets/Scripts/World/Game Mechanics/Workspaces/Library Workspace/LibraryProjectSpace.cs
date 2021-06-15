using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "libraryProjectSpace", menuName = "Workspaces/Library/Project Space")]
public class LibraryProjectSpace : CityProjectSpace
{
    
    [SerializeField]
    [TabGroup("Static Data")]
    [LabelWidth(100)]
    protected LibraryProjectSpaces spaceID;

    [SerializeField]
    [TabGroup("Static Data")]
    [LabelWidth(100)]
    protected List<LibraryProject> libraryProjects;

    public LibraryProjectSpaces SpaceID { get => spaceID;}
    public List<LibraryProject> LibraryProjects { get => libraryProjects;}
}
