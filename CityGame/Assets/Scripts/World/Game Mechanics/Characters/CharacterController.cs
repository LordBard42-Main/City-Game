using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [Header("Serialization")]
    [SerializeField] protected PathAndFileName pathAndFileName_CharacterInfo;
    [SerializeField] protected CharacterInformation characterInformation;

    [Header("Character Info")]
    [SerializeField] protected Character character;
    [SerializeField] protected Scenes currentScene;

    //Primary Components
    protected EmployeeController employeeController;


    protected virtual void Awake()
    {

        characterInformation.DeserializeInformation(pathAndFileName_CharacterInfo);

        employeeController = GetComponent<EmployeeController>();

    }

    public Character Character { get => character; private set => character = value; }
    public EmployeeController EmployeeController { get => employeeController; set => employeeController = value; }
}
