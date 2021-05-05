using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ClassSerializer
{
    static readonly string PERSISTENTDATAPATH = Application.persistentDataPath;

    public static void SerializeClass(ISerialize classToSerialize, PathAndFileName pathAndFileName)
    {
        var saveFilePath = PERSISTENTDATAPATH + pathAndFileName.Path;

        if(File.Exists(saveFilePath + pathAndFileName.FileName))
        {
            var jsonFromClass = JsonUtility.ToJson(classToSerialize);
            File.WriteAllText(saveFilePath + pathAndFileName.FileName, jsonFromClass);
        }
        else
        {
            if (!Directory.Exists(saveFilePath))
            {
                Directory.CreateDirectory(saveFilePath);
            }

            File.Create(saveFilePath + pathAndFileName.FileName).Dispose();

            var jsonFromClass = JsonUtility.ToJson(classToSerialize);
            File.WriteAllText(saveFilePath + pathAndFileName.FileName, jsonFromClass);
        }


        


    }
    public static ISerialize DeserializeClass(ISerialize classToSerialize, PathAndFileName pathAndFileName)
    {
        string saveFilePath = PERSISTENTDATAPATH + pathAndFileName.Path;

        if (File.Exists(saveFilePath + pathAndFileName.FileName))
        {
            var contentsOfFile = File.ReadAllText(saveFilePath + pathAndFileName.FileName);
            var deserializedClass = (ISerialize)JsonUtility.FromJson(contentsOfFile, classToSerialize.GetType());
            return deserializedClass;
        }
        else
        {
            if(!Directory.Exists(saveFilePath))
            {
                Directory.CreateDirectory(saveFilePath);
            }

            File.Create(saveFilePath + pathAndFileName.FileName).Dispose();
        }

        return default(ISerialize);


    }
}

[System.Serializable]
public class PathAndFileName
{
    [SerializeField] private string path;
    [SerializeField] private string fileName;

    public string Path { get => path; private set => path = value; }
    public string FileName { get => fileName; private set => fileName = value; }
}