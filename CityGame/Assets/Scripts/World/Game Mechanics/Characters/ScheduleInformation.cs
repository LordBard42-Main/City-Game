using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScheduleInformation : ISerialize
{

    [SerializeField] private Week q1;
    [SerializeField] private int hello;


    public void CopyFrom(ISerialize incomingClass)
    {
        var informationClass = incomingClass as ScheduleInformation;
        q1 = informationClass.Q1;

    }

    public void DeserializeInformation(PathAndFileName pathAndFileName)
    {
        var deserialziedClass = ClassSerializer.DeserializeClass(this, pathAndFileName);
        CopyFrom(deserialziedClass);
    }

    public void SerializeInformation(PathAndFileName pathAndFileName)
    {
        ClassSerializer.SerializeClass(this, pathAndFileName);
       
    }

    [JsonProperty]
    public Week Q1 { get => q1; private set => q1 = value; }
}
