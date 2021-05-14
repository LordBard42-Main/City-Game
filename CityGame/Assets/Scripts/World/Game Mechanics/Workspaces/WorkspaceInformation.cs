using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkspaceInformation : ISerialize
{
    [SerializeField] private Character head;
    [SerializeField] private Character assistant;

    [SerializeField] private List<CityProjectTicket> projectQueue;
    [SerializeField] private List<CityProjectSpaceHolder> projectSpaces;


    public void CopyFrom(ISerialize incomingClass)
    {
        var tempClass = incomingClass as WorkspaceInformation;
        Head = tempClass.Head;
        assistant = tempClass.Assistant;
        projectQueue = tempClass.projectQueue;
        ProjectSpaces = tempClass.ProjectSpaces;
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
    public Character Head { get => head; set => head = value; }
    public Character Assistant { get => assistant; set => assistant = value; }
    public List<CityProjectTicket> ProjectQueue { get => projectQueue; set => projectQueue = value; }
    public List<CityProjectSpaceHolder> ProjectSpaces { get => projectSpaces; set => projectSpaces = value; }
}

