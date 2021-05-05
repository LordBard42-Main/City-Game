using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LibrarySkill : Skill
{
    private Skills type = Skills.LibrarySkill;

    public override Skills GetSkillType()
    {
        return type;
    }
}
