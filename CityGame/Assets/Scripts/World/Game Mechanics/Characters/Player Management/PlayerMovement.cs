using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private Vector2 movement;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 directionFacing = new Vector2();

    public Vector2 DirectionFacing { get => directionFacing; private set => directionFacing = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        movement.x = (Input.GetAxisRaw("Horizontal"));
        movement.y = (Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {

        var position = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //This Makes it so you end on the right idle animation and that the directional ray is always outFront.
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetFloat("LastMoveHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveVertical", 0);
            directionFacing.x = Input.GetAxisRaw("Horizontal");
            directionFacing.y = 0;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveVertical", Input.GetAxisRaw("Vertical"));
            animator.SetFloat("LastMoveHorizontal", 0);
            directionFacing.y = Input.GetAxisRaw("Vertical");
            directionFacing.x = 0;
        }

        rb.MovePosition(position);
        



    }

    public void SetRbPosition(Vector2 position)
    {
        transform.position = position;
    }


}
