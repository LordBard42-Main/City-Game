using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CityProjectSpaceRefrence
{
    private string name = "ProjectSpaceRefrence";

    [SerializeField] private Scenes scene;
    [SerializeField] private Vector2 location;
    [SerializeField] private Transform projectSpace;

    [Header("City Project Information")]
    [SerializeField] private CityProject cityProject;
    [SerializeField] private float amountOfWorkComplete;

    public CityProject CityProject { get => cityProject; set => cityProject = value; }
    public Scenes Scene { get => scene; private set => scene = value; }
    public Vector2 Location { get => location; private set => location = value; }
    public Transform ProjectSpace { get => projectSpace; private set => projectSpace = value; }
    public float AmountOfWorkComplete { get => amountOfWorkComplete; set => amountOfWorkComplete = value; }
}
