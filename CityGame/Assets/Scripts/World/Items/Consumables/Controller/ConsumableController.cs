using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 1.When Creating a new ite, set the item parent down below;
/// </summary>
public class ConsumableController : RadialPickup
{
    public ConsumableItem consumable;
    public bool state = false;
    public Sprite currentSprite;
    private IEnumerator coroutine;

    


    override public void Start()
    {
        base.Start();
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GetComponent<Collider2D>());
        coroutine = LateLoad();
        StartCoroutine(coroutine);
    }

    IEnumerator LateLoad()
    {
        yield return new WaitForSeconds((float).1);
        //int x, y;
        
    }
    public override void Pickup()
    {
        base.Pickup();
        PlayerController.instance.PlayerInventory.AddItem(consumable);
        Destroy(gameObject);
    }

    public override void Use()
    {
        base.Use();
       
    }
    

    public ConsumableItem getItem()
    {
        return consumable;
    }
}
