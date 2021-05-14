using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CityProjectHolder
{
    [SerializeField] private CityProject cityProject;
    [SerializeField] private bool needsWorked;

    public CityProject CityProject { get => cityProject; set => cityProject = value; }
    public bool NeedsWorked { get => needsWorked; set => needsWorked = value; }
}
