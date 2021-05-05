using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Scenes goesTo;
    public Scenes GoesTo { get => goesTo; set => goesTo = value; }
}
