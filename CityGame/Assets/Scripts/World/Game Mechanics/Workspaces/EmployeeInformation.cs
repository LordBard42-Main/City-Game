using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmployeeInformation : ISerialize
{
    [JsonIgnore]
    public IWorkspace workspace;

    //Ignored because it is set by the workspace to avoid issues
    [JsonIgnore]
    public Employee_Type employee_Type;
    public bool isEmployed;

    //TicketInformation
    [SerializeReference]
    [JsonConverter(typeof(ProjectTicketConverter))]
    public ICityProjectTicket currentProject;
    public bool hasATicket;

    public void CopyFrom(ISerialize incomingClass)
    {
        var tempClass = incomingClass as EmployeeInformation;

        isEmployed = tempClass.isEmployed;
        hasATicket = tempClass.hasATicket;
        
    }

    public void DeserializeInformation(PathAndFileName pathAndFileName)
    {
        var deserializedClass = ClassSerializer.DeserializeClass(this, pathAndFileName);
        CopyFrom(deserializedClass);
    }

    public void SerializeInformation(PathAndFileName pathAndFileName)
    {
        ClassSerializer.SerializeClass(this, pathAndFileName);
    }
}

public class ProjectTicketConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(ICityProjectTicket));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return serializer.Deserialize(reader, typeof(CityProjectTicket));
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value, typeof(CityProjectTicket));
    }
}
