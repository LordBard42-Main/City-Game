using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum ProjectSize_IDs { All, Small, Medium, Large}

public class CityProject : ScriptableObject
{

    [SerializeField]
    [TabGroup("Project Data")]
    [LabelWidth(100)]
    [ReadOnly] 
    protected ProjectSize_IDs projectSize;

    [SerializeField]
    [TabGroup("Project Constraints")]
    [LabelWidth(150)]
    [Range(0, 20)] 
    private int skillLevelRequired;

    [SerializeField]
    [TabGroup("Project Constraints")] 
    [LabelWidth(150)]
    [Range(0, 200)] 
    private int timeToComplete;

    public int SkillLevelRequired { get => skillLevelRequired; private set => skillLevelRequired = value; }
    public int TimeToComplete { get => timeToComplete; private set => timeToComplete = value; }
}
