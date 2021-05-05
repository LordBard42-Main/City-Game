using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    [SerializeField] protected Transform inventoryParent;

    protected Inventory inventory;
    [SerializeField] protected InventorySlotUI[] slots;

    public Inventory Inventory { private get => inventory; set => inventory = value; }
    public InventorySlotUI[] Slots { get => slots; protected set => slots = value; }

    
    /// <summary>
    /// Set Inventory, slots, and current inventory slot
    /// </summary>
    protected virtual void Start()
    {
        if(TryGetComponent(out Inventory foundInventory))
        {
            inventory = foundInventory;
            inventory.OnItemChangedCallback += UpdateUI;
        }
        if(TryGetComponent(out Transform foundInventoryParent))
        {
            inventoryParent = foundInventoryParent;
            slots = inventoryParent.GetComponentsInChildren<InventorySlotUI>();
        }
    }
    
    /// <summary>
    /// Updates InventoryUI
    /// </summary>
    protected virtual void UpdateUI( )
    {

        InventorySlotData[] slotData = inventory.GetInventorySlotData();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetSlotUI(slotData[i]);
        }
    }



}
