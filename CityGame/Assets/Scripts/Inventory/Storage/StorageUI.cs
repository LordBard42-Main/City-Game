using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StorageUI : InventoryUI
{
    
    private void OnEnable()
    {
        //SetStorageUI();
    }

    /// <summary>
    /// Updates Storage UI
    /// </summary>
    protected override void UpdateUI( )
    {
        base.UpdateUI();
    }

    /// <summary>
    /// Set Storage UI
    /// </summary>
    public void SetStorageUI(Storage storage)
    {
        inventory = storage;
        slots = inventoryParent.GetComponentsInChildren<InventorySlotUI>();
    }
    
}
