using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// This script make the item work when not physically in the world. Things like inventory managment and such. 
/// This works closely with Item Controller
/// </summary>
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Interactable")]
public class InteractableItem : Item
{
    private void Awake()
    {
        ItemType = ItemType.Interactable;
    }
    public virtual void Use( )
    {
        //Use Item
        //Something might happpen
        Debug.Log("Using Item" + name);

    }

    

}
