using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialPickup : MonoBehaviour
{
    private Vector2 vectorToPlayer;
    private Vector2 forceTowardsPlayer;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float speed = 5f;


    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            
            //movement.x = (collision.GetComponent<Transform>().position - transform.position).normalized.x;
            //movement.y = (collision.GetComponent<Transform>().position - transform.position).normalized.y;

            movement = (collision.GetComponent<Transform>().position - transform.position);

            //vectorToPlayer = (Vector2)transform.position + movement * speed * Time.fixedDeltaTime;
            forceTowardsPlayer = movement * speed * Time.fixedDeltaTime;

            //rb.MovePosition(vectorToPlayer);
            rb.AddForce(forceTowardsPlayer);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Item collided with!" + collision.collider.name);
        if (collision.collider.name == "Player")
        {
            Pickup();
        }
    }

    public virtual void Pickup()
    {

        //Debug.Log("Interacting With " + gameObject.name);
    }

    public virtual void Use()
    {

    }
    
}
