using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryManager : MonoBehaviour
{
    public static BakeryManager instance;
   
    private Inventory bakeryInventory;
    public Inventory BakeryInventory { get => bakeryInventory; set => bakeryInventory = value; }
    

    public delegate void OnBakeryInventoryUpdated();
    public OnBakeryInventoryUpdated OnBakeryInventoryUpdatedCallback;

    public int itemsInShop;


    void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of BakeryManager found");
            Destroy(gameObject);
            return;

        }

        instance = this;
        #endregion


    }

    private void Start()
    {
        bakeryInventory = GetComponent<Inventory>();
    }


    public Tuple<bool,int> AddItem(Item item, int quantity, int price)
    {
        var wasAdded = bakeryInventory.AddItem(item, quantity, price);

        if(wasAdded.Item1)
        {
            if (OnBakeryInventoryUpdatedCallback != null)
                OnBakeryInventoryUpdatedCallback.Invoke();
        }
        return wasAdded;
    }

    public void RemoveItem(int slot, int quantity)
    {
        bakeryInventory.RemoveItem(slot, quantity);


        if (OnBakeryInventoryUpdatedCallback != null)
            OnBakeryInventoryUpdatedCallback.Invoke();
    }

}
