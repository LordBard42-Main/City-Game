using UnityEngine;
using UnityEngine.Tilemaps;

[System.Flags]
public enum ItemType{ Placeable, Consumable, Interactable}
public enum ItemQuality { None,Low, Medium, High, Legendary}

/// <summary>
/// This script make the item work when not physically in the world. Things like inventory managment and such. 
/// This works closely with Item Controller
/// </summary>
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Basic Item Info")]
    new public string name = "New Item";
    [SerializeField] private Items id;
    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite icon = null;
    [SerializeField] private Transform currentPrefab;
    [SerializeField] private int baseCost;
    [SerializeField] private string description;
    [SerializeField] private ItemPrefabs states;
    //[Space(20)]

    #region Inventory Managment
    [Header("Inventory Management")]
    [SerializeField] private bool isStackable = false;
    [SerializeField] private bool isDefaultItem = false;
    [SerializeField] private int stackLimit;
    #endregion


    public Items ID { get => id; set => id = value; }
    public ItemType ItemType { get => itemType; set => itemType = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public Transform CurrentPrefab { get => currentPrefab; set => currentPrefab = value; }
    public int BaseCost { get => baseCost; set => baseCost = value; }
    public string Description { get => description; set => description = value; }
    public ItemPrefabs States { get => states; set => states = value; }
    public bool IsStackable { get => isStackable; set => isStackable = value; }
    public bool IsDefaultItem { get => isDefaultItem; set => isDefaultItem = value; }
    public int StackLimit { get => stackLimit; set => stackLimit = value; }


}
