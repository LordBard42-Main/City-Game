using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillInformation : ISerialize
{

    [Header("Skills")]
    [SerializeField] private LibrarySkill librarySkill;
    [SerializeField] private ConstructionSkill constructionSkill;

    public void CopyFrom(ISerialize incomingClass)
    {
        SkillInformation tempClass = incomingClass as SkillInformation;
        librarySkill = tempClass.LibrarySkill;
        constructionSkill = tempClass.ConstructionSkill;


    }

    public void DeserializeInformation(PathAndFileName pathAndFileName)
    {
        ISerialize newClass = ClassSerializer.DeserializeClass(this, pathAndFileName);

        if (newClass != null)
            CopyFrom(newClass);
    }

    public void SerializeInformation(PathAndFileName pathAndFileName)
    {
        ClassSerializer.SerializeClass(this, pathAndFileName);
    }

    public LibrarySkill LibrarySkill { get => librarySkill; private set => librarySkill = value; }
    public ConstructionSkill ConstructionSkill { get => constructionSkill; private set => constructionSkill = value; }
}
