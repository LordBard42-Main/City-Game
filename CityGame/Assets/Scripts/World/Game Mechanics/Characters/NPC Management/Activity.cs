using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : ScriptableObject
{
    [SerializeField] protected Scenes scene;
    [SerializeField] protected Vector2 location;


   

    public Scenes Scene { get => scene; private set => scene = value; }
    public Vector2 Location { get => location;  private set => location = value; }
}
