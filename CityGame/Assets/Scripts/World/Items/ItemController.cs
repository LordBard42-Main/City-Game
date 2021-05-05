using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 1.When Creating a new item, set the item parent down below;
/// </summary>
public class ItemController : Interactable
{
    public Item item;
    public Vector2 position;
    public bool state = false;
    public Sprite currentSprite;



    public virtual void Start()
    {
        //Do nothing yet
    }


    public override void Interact()
    {
        base.Interact();
    }

    public override void Use()
    {
        base.Use();
       
    }
    

    public Vector2 getItemPosition()
    {
        return position;
    }

    public void setItemPosition(Vector2 position)
    {
        this.position = position;

    }

    public Item getItem()
    {
        return item;
    }
}
