using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField] private PathAndFileName pathAndFileName_Skill;
    [SerializeField] private SkillInformation skillInformation;

    private void Awake()
    {
        skillInformation.DeserializeInformation(pathAndFileName_Skill);
    }


    private void OnDestroy()
    {
        skillInformation.SerializeInformation(pathAndFileName_Skill);
    }

    public Skill GetSkill(Skills skillID)
    {

        switch (skillID)
        {
            case Skills.LibrarySkill:
                return skillInformation.librarySkill;
            case Skills.ConstructionSkill:
                return skillInformation.constructionSkill;
            default:
                break;
        }
        return default(Skill);
    }

}
