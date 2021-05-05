using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIPrefabHolder : PrefabsHolder
{ 
    [Header("UI")]
    [SerializeField] private Transform itemCard;
    [SerializeField] private Transform inventoryTray;


    //UI
    public Transform ItemCard { get => itemCard; set => itemCard = value; }
    public Transform InventoryTray { get => inventoryTray; set => inventoryTray = value; }
}
