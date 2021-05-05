using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInventoryUI : InventoryUI
{
    
    
    [SerializeField] private Text currentInventorySlotText;
    
    protected Text CurrentInventorySlotText { get => currentInventorySlotText; set => currentInventorySlotText = value; }


    /// <summary>
    /// I am not using the base.start as the Player inventoryUI is a singleton.
    /// It is a special case
    /// </summary>
    protected override void Start()
    {
        base.Start();

        inventory = PlayerController.instance.PlayerInventory;

        inventory.OnItemChangedCallback += UpdateUI;
    }

    /// <summary>
    /// Updates player inventory UI
    /// </summary>
    protected override void UpdateUI( )
    {
        base.UpdateUI();
    }

    /*
    /// <summary>
    /// Scrolls through the inventory slots with mouse wheel
    /// </summary>
    void UINavigation()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
        {
            currentItemIndexFloat += Input.GetAxis("Mouse ScrollWheel") * 10;
            currentItemIndexInt = (int)currentItemIndexFloat;
            if (currentItemIndexInt > 8)
            {
                currentItemIndexInt = 0;
                currentItemIndexFloat = 0;
            }
            else if (currentItemIndexInt < 0)
            {
                currentItemIndexInt = 8;
                currentItemIndexFloat = 8;
            }
        }
    }
    */
    
}
