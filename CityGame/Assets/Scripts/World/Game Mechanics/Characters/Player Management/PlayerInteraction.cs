using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System;

public class PlayerInteraction : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private Transform playerTransform;

    [SerializeField] private LayerMask layerMask;
    private Collider2D hit;

    //Box Variables
    [SerializeField] private Vector2 origin = new Vector2();
    private Vector2 directionFacing;
    private float distance = 2;
    private Vector2 boxSize = new Vector2();

    public GameObject interactSymbol;
    private bool interactable;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerTransform = transform.GetChild(0).transform;
    }

    void Update()
    {
        DrawBox();

        if(hit != null)
        {
            interactable = hit.TryGetComponent(out Interactable interact);
            
            if(!interactable)
                interactable = hit.transform.parent.TryGetComponent(out Interactable interact2);
        }
        else
        {
            interactable = false;
        }

        interactSymbol.SetActive(interactable);
    }

    private void DrawBox()
    {
        directionFacing = playerMovement.DirectionFacing;
        origin = playerTransform.position;
        Vector2 point1 = new Vector2();
        Vector2 point2 = new Vector2();

        if (directionFacing.x == 1)
        {
            point1 = new Vector2(0, -3f) + origin;
            point2 = new Vector2(1, -2.75f) + origin;
        }
        else if (directionFacing.x == -1)
        {
            point1 = new Vector2(0, -3f) + origin;
            point2 = new Vector2(-1, -2.75f) + origin;
        }
        else if (directionFacing.y == 1)
        {
            point1 = new Vector2(-.25f, -3) + origin;
            point2 = new Vector2(.25f, -2) + origin;
        }
        else if (directionFacing.y == -1)
        {
            point1 = new Vector2(-.25f, -3) + origin;
            point2 = new Vector2(.25f, -4) + origin;
        }

        hit = Physics2D.OverlapArea(point1, point2, layerMask);
    }

    public Tuple<bool, Collider2D> GetInteractInfo()
    {
        return new Tuple<bool, Collider2D>(interactable, hit);
    }

}
