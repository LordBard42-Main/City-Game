using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectSpaceID { TS1, TS2 }
[System.Serializable]
public class ConstructionSpace
{
    [Header("Project Space Details")]
    [SerializeField] private Vector2 coordinates;
    [SerializeField] private ProjectSpaceID id;
    [SerializeField] private ProjectSize_IDs spaceSize;


    [Header("Project Space Build Data")]
    [SerializeField] private CityProject currentBuild;
    [SerializeField] private bool isUnderConstruction;
    [SerializeField] private bool isSpaceOccupied;

    [Header("Construction Data")]
    [SerializeField] private float currentBuildProgress;
    [SerializeField] private CalendarTimeStamp constructionStartDate;
    [SerializeField] private CalendarTimeStamp ConstructionFinishDate;

    public ProjectSpaceID Id { get => id; set => id = value; }
    public CityProject CurrentBuild { get => currentBuild; set => currentBuild = value; }
    public bool IsUnderConstruction { get => isUnderConstruction; set => isUnderConstruction = value; }
    public float CurrentBuildProgress { get => currentBuildProgress; set => currentBuildProgress = value; }
    public bool IsSpaceOccupied { get => isSpaceOccupied; set => isSpaceOccupied = value; }

    public ConstructionSpace(ProjectSpaceID id)
    {
        this.id = id;
    }
}
