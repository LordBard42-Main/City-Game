using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{

    public static PlayerController instance;

    private Inventory playerInventory;
    private PlayerMovement playerMovement;
    private PlayerInteraction playerInteraction;



    public delegate void OnPlayerInventoryUpdated();
    public OnPlayerInventoryUpdated PlayerInventoryUpdated;

    protected override void Awake()
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

        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponentInChildren<Inventory>();
        PlayerMovement = GetComponentInChildren<PlayerMovement>();
        PlayerInteraction = GetComponentInChildren<PlayerInteraction>();
       
        
    }
    private void OnDestroy()
    {
        characterInformation.SerializeInformation(pathAndFileName_CharacterInfo);
    }

    public Inventory PlayerInventory { get => playerInventory; private set => playerInventory = value; }
    public PlayerMovement PlayerMovement { get => playerMovement; private set => playerMovement = value; }
    public PlayerInteraction PlayerInteraction { get => playerInteraction; private set => playerInteraction = value; }
    public CharacterInformation CharacterInformation { get => characterInformation; private set => characterInformation = value; }


}
