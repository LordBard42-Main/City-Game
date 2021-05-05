using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Items
{
    Default = 0,
    //Placeables
    Bench = 1, StreetLight = 2, SpringTree = 3, TrashCan = 4, Stove = 5, PineTree = 6, Fridge = 7,
    

    //Consumables
    BlueBerry = 1000, Cherry = 1001, BaseMixture = 1002, CherryMuffin = 1003, Sprinkles = 1004, BlueberryMuffin = 1005,
};
public enum ActionsForItem { GetItemPrefab }

/// <summary>
/// The purpose of this class is to hold the methods that need to perform an action based on an items ID.
/// </summary>
public class ItemIDMangager : MonoBehaviour
{ 
    #region  Singleton

    public static ItemIDMangager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("ItemIDMangager already exists");
            return;
        }
        instance = this;
    }
    #endregion

    PrefabManager prefabManager;
    GameManager gameManager;
    private Item item;
    private Items itemID;

    #region Get Item Prefab
    //Not really needed
    #endregion

    private void Start()
    {
        prefabManager = PrefabManager.instance;
        gameManager = GameManager.instance;
    }
    
    /// <summary>
    /// Recieve an action and return an Item
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public Item ActionsBasedOnItem(ActionsForItem action)
    {

        switch (action)
        {
            //Gets Item Prefab
            case ActionsForItem.GetItemPrefab:
                switch (itemID)
                {
                    case Items.Bench:
                        item = prefabManager.Interactables.Bench.GetComponent<InteractableController>().item;
                        //Debug.Log(item.icon);
                        break;
                    case Items.StreetLight:
                        item = prefabManager.Interactables.StreetLight.GetComponent<InteractableController>().item;
                        //Debug.Log(item.icon);
                        break;
                    case Items.SpringTree:
                        item = prefabManager.Interactables.SpringTree.GetComponent<InteractableController>().item;
                        //Debug.Log(item.icon);
                        break;
                    case Items.TrashCan:
                        item = prefabManager.Interactables.TrashCan.GetComponent<InteractableController>().item;
                        break;
                    case Items.Stove:
                        item = prefabManager.Interactables.Stove.GetComponent<InteractableController>().item;
                        break;
                    case Items.PineTree:
                        item = prefabManager.Interactables.PineTree.GetComponent<InteractableController>().item;
                        break;


                    ///CONSUMABLES START!
                    ///
                    case Items.BlueBerry:
                        item = prefabManager.Consumables.BlueBerry.GetComponent<ConsumableController>().consumable;
                        break;
                    case Items.Cherry:
                        item = prefabManager.Consumables.Cherry.GetComponent<ConsumableController>().consumable;
                        break;
                    case Items.CherryMuffin:
                        item = prefabManager.Consumables.CherryMuffin.GetComponent<ConsumableController>().consumable;
                        break;
                    case Items.BaseMixture:
                        item = prefabManager.Consumables.BaseMixture.GetComponent<ConsumableController>().consumable;
                        break;
                    case Items.Sprinkles:
                        item = prefabManager.Consumables.Sprinkles.GetComponent<ConsumableController>().consumable;
                        break;
                    case Items.BlueberryMuffin:
                        item = prefabManager.Consumables.BlueBerryMuffin.GetComponent<ConsumableController>().consumable;
                        break;
                }
                break;

        }

        return null;
    }

    public Item GetItemPrefab(Items itemID)
    {
        this.itemID = itemID;
        ActionsBasedOnItem(ActionsForItem.GetItemPrefab);
        return item;
    }

}
