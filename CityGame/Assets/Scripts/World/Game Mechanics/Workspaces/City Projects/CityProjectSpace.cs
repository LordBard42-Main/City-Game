using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityProjectSpace : ScriptableObject
{
    protected readonly string name = "ProjectSpaceRefrence";

    [SerializeField] protected Scenes scene;
    [SerializeField] protected Vector2 location;
    [SerializeField] protected Transform projectSpace;

    private bool isBeingWorkedOn;



    public Scenes Scene { get => scene; }
    public Vector2 Location { get => location; protected set => location = value; }
    public Transform ProjectSpace { get => projectSpace; protected set => projectSpace = value; }
    public bool IsBeingWorkedOn { get => isBeingWorkedOn; set => isBeingWorkedOn = value; }
}
