using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDisplayController : Interactable
{

    [SerializeField] private Inventory shopInventory;
    [SerializeField] private Inventory itemCardInventory;
    [SerializeField] private GameObject itemCardCanvas;

    public Inventory ShopInventory { get => shopInventory; set => shopInventory = value; }

    public override void Interact()
    {
        base.Interact();


    }
    
}
