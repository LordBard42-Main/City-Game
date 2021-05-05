using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractablePrefabsHolder : PrefabsHolder
{
    [Header("Interactables")]
    [SerializeField] private Transform bench;
    [SerializeField] private Transform streetLight;
    [SerializeField] private Transform springTree;
    [SerializeField] private Transform trashCan;
    [SerializeField] private Transform stove;
    [SerializeField] private Transform pineTree;

    public Transform Bench { get => bench; set => bench = value; }
    public Transform StreetLight { get => streetLight; set => streetLight = value; }
    public Transform SpringTree { get => springTree; set => springTree = value; }
    public Transform TrashCan { get => trashCan; set => trashCan = value; }
    public Transform Stove { get => stove; set => stove = value; }
    public Transform PineTree { get => pineTree; set => pineTree = value; }
}
