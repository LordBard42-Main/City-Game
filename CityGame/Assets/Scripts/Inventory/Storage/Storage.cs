using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StorageType {Refrigerator, Chest }

public class Storage : Inventory
{
    [Header("Invetory Information")]
    public static readonly int space = 27;
    public StorageType storageType;

    public string uniqueID = "1";
    

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        
    }

    /// <summary>
    /// Updates the correct storage node in Storage Manager. This is done
    /// so that when the scene is saved, the chests current data is saved
    /// </summary>
    private void OnDisable()
    {
    }

    /// <summary>
    /// I am planning on using this for Placeable chests. Not done yet.
    /// </summary>
    private void OnDestroy()
    {
    }

    /// <summary>
    /// Takes item and adds it to the first stack found or to the first empty slot
    /// If neither option is available, does not add item and returns false
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public override Tuple<bool,int> AddItem(Item item)
    {
        return base.AddItem(item);
    }

    /// <summary>
    /// Adds Item By Slot Number
    /// </summary>
    /// <param name="slotNumber"></param>
    /// <param name="item"></param>
    public override bool AddItem(int slotNumber, Item item)
    {
        return base.AddItem(slotNumber, item);
    }

    /// <summary>
    /// Removes the first instance of item found
    /// </summary>
    /// <param name="item"></param>
    public override void RemoveItem(Item item)
    {
        base.RemoveItem(item);
    }

    /// <summary>
    /// Removes Item By Slot Number
    /// </summary>
    /// <param name="slotNumber"></param>
    /// <param name="item"></param>
    public override void RemoveItem(int slotNumber)
    {
        base.RemoveItem(slotNumber);
    }

    /// <summary>
    /// Collects items in inventory and puts them in unique stacks.
    /// </summary>
    /// <returns></returns>
    public override InventorySlotData[] GetItems()
    {
        return base.GetItems();
    }


}
