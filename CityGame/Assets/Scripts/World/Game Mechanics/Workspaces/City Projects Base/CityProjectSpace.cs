using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class CityProjectSpace : SerializedScriptableObject
{
    [SerializeField]
    [LabelWidth(100)]
    protected Scenes scene;
    
    [SerializeField]
    [LabelWidth(100)]
    protected Vector2 location;

    [SerializeField]
    [LabelWidth(100)]
    protected Transform projectSpace;


    public Scenes Scene { get => scene; private set => scene = value; }
    public Vector2 Location { get => location; private set => location = value; }
    public Transform ProjectSpace { get => projectSpace; private set => projectSpace = value; }
}
