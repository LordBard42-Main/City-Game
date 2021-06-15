using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillInformation : ISerialize
{

    [Header("Skills")]
    [SerializeField] public LibrarySkill librarySkill;
    [SerializeField] public ConstructionSkill constructionSkill;

    public void CopyFrom(ISerialize incomingClass)
    {
        SkillInformation tempClass = incomingClass as SkillInformation;
        librarySkill = tempClass.librarySkill;
        constructionSkill = tempClass.constructionSkill;


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

}
