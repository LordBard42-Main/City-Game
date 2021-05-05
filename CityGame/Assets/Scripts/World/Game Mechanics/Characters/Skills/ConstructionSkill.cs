using System.Collections;
using UnityEngine;

public class ConstructionSkill : Skill
{
    private Skills type = Skills.ConstructionSkill;
    public override Skills GetSkillType()
    {
        return type;
    }
}
