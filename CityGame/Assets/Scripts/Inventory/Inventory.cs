using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    protected int length;

    [SerializeField] protected InventorySlot[] slots;

    public InventorySlot[] Slots { get => slots; protected set => slots = value; }
    protected int Length { get => length; set => length = value; }

    protected virtual void Awake()
    {
        length = slots.Length;
        for (int i = 0; i < length; i++)
        {
            slots[i].ID = i;

            if(slots[i].Count == 0)
            {
                slots[i].ClearSlot();
            }
        }
        
    }
    
    /// <summary>
    /// Takes item and adds it to the first stack found or to the first empty slot
    /// If neither option is available, does not add item and returns false
    /// </summary>
    /// <param name="item"></param>-
    /// <returns></returns>
    public virtual Tuple<bool,int> AddItem(Item item)
    {
        int firstEmptySlot = -1;

        if (item != null && !item.IsDefaultItem)
        {
            ///Check if there is already a stack of said item in inventory, if so, attempt to stack it on top.
            for (int i = 0; i < slots.Length; i++)
            {
                ///If item is found, check to see if there is enough room
                if (slots[i].Item == item )
                {
                    if(slots[i].IsFull)
                    {
                        //Debug.Log("Item Not Allowed Or Slot Is Full");
                        continue;
                    }
                    else
                    {
                        slots[i].AddItem(item);
                        if (OnItemChangedCallback != null)
                            OnItemChangedCallback.Invoke();
                        return Tuple.Create(true,i);
                    }
                }

                ///Sets the first empty slot if found
                if (slots[i].IsEmpty && firstEmptySlot == -1)
                {
                    firstEmptySlot = i;
                }
            }

            ///If no previous item found, place item in the first empty slot if it exists
            if (firstEmptySlot != -1)
            {

                slots[firstEmptySlot].AddItem(item);
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();
                return (Tuple.Create(true, firstEmptySlot));
            }
            else
            {
                //Debug.Log("FirstEmpty Not found!" + firstEmptySlot);
            }
            
        }


        Debug.Log("Not Enough Room");
        return (Tuple.Create(false, -1));
    }

    /// <summary>
    /// Adds item with amount
    /// </summary>
    /// <param name="item"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    public virtual Tuple<bool, int> AddItem(Item item, int quantity)
    {
        int firstEmptySlot = -1;

        if (!item.IsDefaultItem)
        {
            ///Check if there is already a stack of said item in inventory, if so, attempt to stack it on top.
            for (int i = 0; i < slots.Length; i++)
            {
                ///If item is found, check to see if there is enough room
                if (slots[i].Item == item)
                {
                    if (!slots[i].CanStoreItem(quantity) || slots[i].IsSlotFull())
                    {
                        continue;
                    }
                    else
                    {
                        slots[i].AddItem(item, quantity);
                        if (OnItemChangedCallback != null)
                            OnItemChangedCallback.Invoke();
                        return (Tuple.Create(true, i));
                    }
                }

                ///Sets the first empty slot if found
                if (slots[i].IsEmpty && firstEmptySlot == -1)
                {
                    firstEmptySlot = i;
                }
            }

            ///If no previous item found, place item in the first empty slot if it exists
            if (firstEmptySlot != -1)
            {

                slots[firstEmptySlot].AddItem(item);
                quantity--;
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();


                while (!slots[firstEmptySlot].IsSlotFull())
                {
                    if (quantity > 0)
                    {
                        slots[firstEmptySlot].AddItem(item);
                        quantity--;
                    }
                    else{
                        break;
                    }
                }

                if(quantity > 0)
                {
                    firstEmptySlot = -1;
                    AddItem(item, quantity); //Recoursion Here
                }

                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();
                return (Tuple.Create(true, firstEmptySlot));
            }
            else
            {
                Debug.Log("FirstEmpty Not found!" + firstEmptySlot);
            }

        }


        Debug.Log("Not Enough Room");
        return (Tuple.Create(false, -1));
    }

    /// <summary>
    /// Adds Item with amount and price
    /// </summary>
    /// <param name="item"></param>
    /// <param name="quantity"></param>
    /// <param name="price"></param>
    /// <returns></returns>
    public virtual Tuple<bool, int> AddItem(Item item, int quantity, int price)
    {
        int firstEmptySlot = -1;

        if (!item.IsDefaultItem)
        {
            ///Check if there is already a stack of said item in inventory, if so, attempt to stack it on top.
            for (int i = 0; i < slots.Length; i++)
            {
                ///If item is found, check to see if there is enough room
                if (slots[i].Item == item)
                {
                    if (!slots[i].CanStoreItem(quantity) || slots[i].IsSlotFull())
                    {
                        Debug.Log("Item Not Allowed in slot!");
                        continue;
                    }
                    else if(slots[i].Price != price)
                    {
                        Debug.Log("Items do not cost the same");
                        continue;
                    }
                    else
                    {
                        Debug.Log(quantity);
                        slots[i].AddItem(item, quantity, price);
                        if (OnItemChangedCallback != null)
                            OnItemChangedCallback.Invoke();
                        return (Tuple.Create(true, i));
                    }
                }

                ///Sets the first empty slot if found
                if (slots[i].IsEmpty && firstEmptySlot == -1)
                {
                    firstEmptySlot = i;
                }
            }

            ///If no previous item found, place item in the first empty slot if it exists
            if (firstEmptySlot != -1)
            {

                slots[firstEmptySlot].AddItem(item);
                slots[firstEmptySlot].Price = price;
                quantity--;
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();


                while (!slots[firstEmptySlot].IsSlotFull())
                {
                    if (quantity > 0)
                    {
                        slots[firstEmptySlot].AddItem(item);
                        quantity--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (quantity > 0)
                {
                    firstEmptySlot = -1;
                    AddItem(item, quantity, price);
                }

                
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();
                return (Tuple.Create(true, firstEmptySlot));
            }
            else
            {
                Debug.Log("FirstEmpty Not found!" + firstEmptySlot);
            }

        }


        Debug.Log("Not Enough Room");
        return (Tuple.Create(false, -1));
    }

    /// <summary>
    /// Adds Item By Slot Number
    /// </summary>
    /// <param name="slotNumber"></param>
    /// <param name="item"></param>
    public virtual bool AddItem(int slotNumber, Item item)
    {
        if(!slots[slotNumber].IsFull || !slots[slotNumber].IsSlotFull())
        {
            slots[slotNumber].AddItem(item);
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Removes the first instance of item found
    /// </summary>
    /// <param name="item"></param>
    public virtual void RemoveItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //If item is found, remove and return
            if (slots[i].Item == item)
            {
                slots[i].RemoveItem();
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();
                return;
            }
        }


    }
    /// <summary>
     /// Removes the first instances of item found
     /// </summary>
     /// <param name="item"></param>
    public virtual void RemoveItem(Item item, int quantity)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //If item is found, remove and return
            if (slots[i].Item == item)
            {
                while (slots[i].Count > 0)
                {
                    if (quantity > 0)
                    {
                        slots[i].RemoveItem();
                        quantity--;
                    }
                    else
                    {
                        if (OnItemChangedCallback != null)
                            OnItemChangedCallback.Invoke();
                        return;
                    }
                }
            }

        }

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
        return;

    }

    /// <summary>
    /// Removes Item By Slot Number
    /// </summary>
    /// <param name="slotNumber"></param>
    /// <param name="item"></param>
    public virtual void RemoveItem(int slotNumber)
    {
        slots[slotNumber].RemoveItem();
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();

    }

    /// <summary>
    /// Removes Itemsds By Slot Number
    /// </summary>
    /// <param name="slotNumber"></param>
    /// <param name="item"></param>
    public virtual void RemoveItem(int slotNumber, int quantity)
    {
        while (slots[slotNumber].Count > 0)
        {
            if (quantity > 0)
            {
                slots[slotNumber].RemoveItem();
                quantity--;
            }
            else
            {
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();
                return;
            }
        }

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();

    }

    /// <summary>
    /// Clears all the slots
    /// </summary>
    public void ClearAllSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].ClearSlot();
        }

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();

    }

    /// <summary>
    /// Collects items in inventory and puts them in unique stacks.
    /// </summary>
    /// <returns></returns>
    public virtual InventorySlotData[] GetItems()
    {
        //Using this so I don't tamper with original
        InventorySlotData[] TemporarySlots = new InventorySlotData[9]
        {
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
        };

        //Shallow copy data
        for (int i = 0; i < slots.Length; i++)
        {
            TemporarySlots[i].CopyData(slots[i]);
        }

        //This is the outbound items for shop, it will have the combined total of items in inventory
        InventorySlotData[] ItemsForShop = new InventorySlotData[9]
        {
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
            new InventorySlotData(),
        };


        //This is just the count for number of items going to the shop;
        int ItemIndexForShop = 0;

        //This runs through the temporary slots to get items
        for (int i = 0; i < TemporarySlots.Length; i++)
        {
            //If there is an item in a slot, add it to ItemsForShop
            if (!TemporarySlots[i].IsEmpty)
            {
                //Debug.Log(ItemsForShop[ItemIndexForShop]);
                ItemsForShop[ItemIndexForShop].SetSlotData(TemporarySlots[i].Item, TemporarySlots[i].Count, TemporarySlots[i].IsEmpty);

                //Check for other stacks of the same item and add them to the outbound item count.
                //Then clear to make sure duplicates are not created
                //Start at i + 1 to avoid adding the current TempSlot a second time
                for (int n = i + 1; n < TemporarySlots.Length; n++)
                {
                    if (ItemsForShop[ItemIndexForShop].Item == TemporarySlots[n].Item)
                    {
                        ItemsForShop[ItemIndexForShop].AddAmount(TemporarySlots[n].Count);
                        TemporarySlots[n].ClearSlot();
                    }
                }

                ItemIndexForShop++;
            }

        }

        return ItemsForShop;
    }

    /// <summary>
    /// Retruns Inventory as an Array of basic InventoryData
    /// </summary>
    /// <returns></returns>
    public InventorySlotData[] GetInventorySlotData()
    {
        InventorySlotData[] slotData = new InventorySlotData[length];

        for (int i = 0; i < length; i++)
        {
            slotData[i] = new InventorySlotData();
            slotData[i].CopyData(slots[i]);
        }

        return slotData;
    }

    public virtual int GetTotalOfSpeceficItem(Item item)
    {
        int total = 0;

        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].Item == item)
            {
                total += slots[i].Count;
            }
        }

        return total;

    }

    public void CopyInventory(InventorySlotData[] slots)
    {
        for (int i = 0; i < this.slots.Length; i++)
        {
            this.slots[i].CopyData(slots[i]);
        }
    }
}


[System.Serializable]
public class InventorySlot
{

    [Header("Base Slot Data")]
    [SerializeField] private Item item;
    [SerializeField] private int id;
    [SerializeField] private int count = 0;
    [SerializeField] private int price;
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private bool isFull = false;

    public Item Item { get => item; set => item = value; }
    public int Count { get => count; set => count = value; }
    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    public bool IsFull { get => isFull; set => isFull = value; }
    public int ID { get => id; set => id = value; }
    public int Price { get => price; set => price = value; }

    public InventorySlot(int index)
    {
        id = index;

    }

    /// <summary>
    /// Used by inventory, sets/changes data when item is added to slot
    /// </summary>
    /// <param name="newItem"></param>
    public void AddItem(Item newItem)
    {
        if (count == 0)
        {
            item = newItem;
            isEmpty = false;
            count = 1;
            price = newItem.BaseCost;
        }
        else
        {
            AddExistingItemToStack(1);
        }
    }

    /// <summary>
    /// Used by inventory, sets/changes data when item is added to slot
    /// </summary>
    /// <param name="newItem"></param>
    public void AddItem(Item newItem, int quantity)
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
            AddExistingItemToStack(quantity);
        }
    }

    /// <summary>
    /// Used by shop Canvas, lets you change the price
    /// </summary>
    /// <param name="newItem"></param>
    public void AddItem(Item newItem, int quantity, int price)
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
            AddExistingItemToStack(quantity);
        }
    }

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

    public void AddExistingItemToStack(int quantity)
    {
        count += quantity;
    }

    public void RemoveExistingItemFromStack()
    {
        count -= 1;

    }

    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        isFull = false;
        count = 0;
        price = 0;

    }

    public void UseItem()
    {
        if (item != null)
        {
            //item.Use();
        }

    }

    public int GetSlotID()
    {
        return ID;
    }

    /// <summary>
    /// Checks Both Item stack limit and specific slot stack limit
    /// </summary>
    /// <returns></returns>
    public bool IsSlotFull()
    {
        return Item.StackLimit == count;
    }

    /// <summary>
    /// Copys data into InventorySlotData from InventorySlotData
    /// </summary>
    /// <param name="slot"></param>
    public void CopyData(InventorySlotData slot)
    {
        item = slot.Item;
        isEmpty = slot.IsEmpty;
        isFull = slot.IsFull;
        count = slot.Count;
        price = slot.Price;
    }


    public bool CanStoreItem(int quantity)
    {
        return count + quantity <= Item.StackLimit;
    }

}
