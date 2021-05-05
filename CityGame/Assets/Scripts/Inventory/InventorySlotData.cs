using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotData
{

    [SerializeField] private Item item;
    [SerializeField] private int price;
    [SerializeField] private int count;
    [SerializeField] private bool isEmpty;
    [SerializeField] private bool isFull;
    
    public Item Item { get => item; set => item = value; }
    public int Count { get => count; set => count = value; }
    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    public bool IsFull { get => isFull; set => isFull = value; }
    public int Price { get => price; set => price = value; }

    /// <summary>
    /// Default Constructor
    /// </summary>
    public InventorySlotData()
    {
        isEmpty = true;
        count = 0;
        //item = null;
    }

    /// <summary>
    /// Inventory slot screated with item
    /// </summary>
    /// <param name="item"></param>
    public InventorySlotData(Item item)
    {
        this.item = item;
        isEmpty = false;
        count = 1;
    }
    

    /// <summary>
    /// Used by inventory, sets/changes data when item is added to slot
    /// </summary>
    /// <param name="newItem"></param>
    public bool AddItem(Item newItem)
    {
        //Debug.Log("ItemCount: " + itemCountInt);
        if (count == 0)
        {
            item = newItem;
            isEmpty = false;
            isFull = false;
            count = 1;
            price = newItem.BaseCost;
        }
        else if(count >= item.StackLimit)
        {
            isFull = true;
            return false;
        }
        else if (count == item.StackLimit - 1)
        {
            isFull = true;
            AddExistingItemToStack();

        }
        else
        {
            isFull = false;
            AddExistingItemToStack();
        }

        return true;
    }

    /// <summary>
    /// Used by inventory, sets/changes data when item is added to slot
    /// </summary>
    /// <param name="newItem"></param>
    public virtual void AddItem(Item newItem, int quantity)
    {
        Debug.Log("ItemCount: " + count);
        if (count == 0)
        {
            item = newItem;
            isEmpty = false;
            count = quantity;
            price = newItem.BaseCost;

        }
        else
        {
            AddAmount(quantity);
        }
    }

    /// <summary>
    /// Add Item with amount and price.
    /// </summary>
    /// <param name="newItem"></param>
    /// <param name="quantity"></param>
    public virtual void AddItem(Item newItem, int quantity, int price)
    {
        Debug.Log("ItemCount: " + count);
        if (count == 0)
        {
            item = newItem;
            isEmpty = false;
            count = quantity;
            this.price = price;

        }
        else
        {
            AddAmount(quantity);
        }
    }


    /// <summary>
    /// Used when item is being added to existing stack
    /// </summary>
    public void AddExistingItemToStack()
    {
        count += 1;
    }

    /// <summary>
    /// Adds a specified amount to the stack
    /// </summary>
    /// <param name="count"></param>
    public void AddAmount(int count)
    {
        this.count += count;
    }

    /// <summary>
    /// Removes Existing item from stack, if last item, Clears Slot
    /// </summary>
    public void RemoveItem()
    {
        if (count > 1)
        {
            RemoveExistingItemFromStack();
        }
        else
        {
            ClearSlot();
        }

    }
    
    /// <summary>
    /// Used when item removed is not last item
    /// </summary>
    public void RemoveExistingItemFromStack()
    {
        count -= 1;
    }

    /// <summary>
    /// Clears slots, sets values to default
    /// </summary>
    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        count = 0;
        price = 0;

    }

    /// <summary>
    /// Explicitly Set Slot Data
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <param name="isEmpty"></param>
    public void SetSlotData(Item item, int count, bool isEmpty)
    {
        this.item = item;
        this.count = count;
        this.isEmpty = isEmpty;
        this.price = item.BaseCost;
    }
    
    /// <summary>
    /// Copys data into InventorySlotData from regular InventorySlot
    /// </summary>
    /// <param name="slot"></param>
    public virtual void CopyData(InventorySlot slot)
    {
        item = slot.Item;
        isEmpty = slot.IsEmpty;
        count = slot.Count;
        price = slot.Price;
    }

    /// <summary>
    /// Copys data into InventorySlotData from InventorySlotData
    /// </summary>
    /// <param name="slot"></param>
    public virtual void CopyData(InventorySlotData slot)
    {

        item = slot.Item;
        isEmpty = slot.IsEmpty;
        count = slot.Count;
        price = slot.Price;
    }

}
