using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionProject : CityProject
{
    //Construction Project Specific Changes

    [Header("Construction Data")]
    [SerializeField] private Transform buildPrefab;
    [SerializeField] private Transform constructionPrefab;

    protected virtual void OnValidate()
    {
        workspace = Workspace_ID.Construction;
    }

    public Transform BuildPrefab { get => buildPrefab; private set => buildPrefab = value; }
    public Transform ConstructionPrefab { get => constructionPrefab; private set => constructionPrefab = value; }

}
