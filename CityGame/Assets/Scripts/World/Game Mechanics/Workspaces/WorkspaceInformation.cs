using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class WorkspaceInformation : ISerialize
{
    [SerializeField] protected Characters head;
    [SerializeField] protected Characters assistant;


    public virtual void CopyFrom(ISerialize incomingClass)
    {
        var tempClass = incomingClass as WorkspaceInformation;

        Head = tempClass.Head;
        assistant = tempClass.Assistant;
        
        

    }

    public abstract void DeserializeInformation(PathAndFileName pathAndFileName);

    public abstract void SerializeInformation(PathAndFileName pathAndFileName);


    public Characters Head { get => head; set => head = value; }
    public Characters Assistant { get => assistant; set => assistant = value; }
}

