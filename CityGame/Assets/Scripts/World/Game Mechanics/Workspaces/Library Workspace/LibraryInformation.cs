using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class LibraryInformation : WorkspaceInformation
{

    public List<LibraryProjectSpaceHolder> libraryProjectSpaces;

    [TableList]
    public List<LibraryProjectTicket> projectQueue;


    public override void CopyFrom(ISerialize incomingClass)
    {
        base.CopyFrom(incomingClass);

        var tempClass = incomingClass as LibraryInformation;
        var tempLibraryProjectSpaces = tempClass.libraryProjectSpaces;

        for(int i = 0; i < libraryProjectSpaces.Count; i++)
        {
            if(tempLibraryProjectSpaces[i] != null)
            {
                var tempLibraryProjects = tempLibraryProjectSpaces[i].LibraryProjects;
                for (int n = 0; n < libraryProjectSpaces[i].LibraryProjects.Count; n++)
                {
                    if(tempLibraryProjects[n] != null)
                    {
                        var tempLibraryProject = tempLibraryProjects[n];
                        libraryProjectSpaces[i].LibraryProjects[n].WorkReady = tempLibraryProject.WorkReady;
                    }
                }

            }
            
        }

        var tempProjectQueue = tempClass.projectQueue;
        projectQueue = new List<LibraryProjectTicket>();

        if (tempProjectQueue != null)
        {
            for (int i = 0; i < tempProjectQueue.Count; i++)
            {
                var libraryProjectTicket = new LibraryProjectTicket(tempProjectQueue[i].ProjectID, tempProjectQueue[i].ProjectSpaceID);
                projectQueue.Add(libraryProjectTicket);
            }
        }

    }

    public override void DeserializeInformation(PathAndFileName pathAndFileName)
    {
    
        var deserializedClass = ClassSerializer.DeserializeClass(this, pathAndFileName);
        CopyFrom(deserializedClass);
    
    }

    public override void SerializeInformation(PathAndFileName pathAndFileName)
    {
        ClassSerializer.SerializeClass(this, pathAndFileName);
    }

    
}
