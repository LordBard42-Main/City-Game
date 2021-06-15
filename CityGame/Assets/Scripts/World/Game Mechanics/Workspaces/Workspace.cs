using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using System;


public abstract class Workspace : SerializedMonoBehaviour
{
    [EnumToggleButtons]
    [BoxGroup("Workspace Details")]
    [LabelWidth(75)]
    [SerializeField] protected Scenes scene;

    [SerializeField]
    [BoxGroup("Employees")] 
    [LabelWidth(75)]
    protected CharacterController manager;
    [SerializeField]
    [BoxGroup("Employees")] 
    [LabelWidth(75)]
    protected CharacterController assistant;



    protected virtual void Awake()
    {
       

    }


    private void OnDestroy()
    {
        
    }



    public Scenes Scene { get => scene; private set => scene = value; }
}
