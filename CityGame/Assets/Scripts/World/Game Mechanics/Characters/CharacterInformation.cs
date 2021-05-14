using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Must use constructor for path to file
/// </summary>
[System.Serializable]
public class CharacterInformation: ISerialize
{
    [Header("Disposition")]
    [SerializeField] private GenericDictionary<Items, Disposition> itemDisposition;
    [SerializeField] private GenericDictionary<Character, Disposition> characterDisposition;


    public void DeserializeInformation(PathAndFileName pathAndFileName )
    {
        
        ISerialize newClass =  ClassSerializer.DeserializeClass(this, pathAndFileName);

        if(newClass != null)
            CopyFrom(newClass);
    }

    public void SerializeInformation(PathAndFileName pathAndFileName)
    {
        ClassSerializer.SerializeClass(this, pathAndFileName);
    }

    public void CopyFrom(ISerialize incomingClass)
    {
        CharacterInformation tempClass = incomingClass as CharacterInformation;
        itemDisposition = tempClass.ItemDisposition;
    }

    public GenericDictionary<Items, Disposition> ItemDisposition { get => itemDisposition; private set => itemDisposition = value; }
    public GenericDictionary<Character, Disposition> CharacterDisposition { get => characterDisposition; set => characterDisposition = value; }
}
