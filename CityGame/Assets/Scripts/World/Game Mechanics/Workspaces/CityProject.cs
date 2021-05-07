using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectSize_IDs { All, Small, Medium, Large}

public class CityProject : ScriptableObject
{

    [Header("Project Data")]
    [SerializeField] [ReadOnly] protected Workspace_ID workspace;
    [SerializeField] [ReadOnly] protected ProjectSize_IDs projectSize;
    [SerializeField] protected int id;



    [Header("Project Constraints")]
    [SerializeField] [Range(0, 20)] private int skillLevelRequired;

    public Workspace_ID Workspace { get => workspace; private set => workspace = value; }
    public int SkillLevelRequired { get => skillLevelRequired; private set => skillLevelRequired = value; }
}
