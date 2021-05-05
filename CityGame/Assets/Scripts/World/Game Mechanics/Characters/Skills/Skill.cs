using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skills { LibrarySkill, ConstructionSkill }

[System.Serializable]
public abstract class Skill
{
    [SerializeField] private int level;


    public abstract Skills GetSkillType();

    public int Level { get => level; set => level = value; }
}
