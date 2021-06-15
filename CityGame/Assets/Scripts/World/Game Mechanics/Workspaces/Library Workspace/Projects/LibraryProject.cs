using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryProject : CityProject
{
    [SerializeField]
    [TabGroup("Project Data")]
    [LabelWidth(100)]
    protected LibraryProjects id;


    public LibraryProjects Id { get => id; set => id = value; }
}
