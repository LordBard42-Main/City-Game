using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. Create a refrence to the Tranform in the world with the appropriate tag;
/// </summary>
public class WorldObjectParentManager : MonoBehaviour
{
    #region  Singleton

    public static WorldObjectParentManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("WorldObjectParents already exists");
            return;
        }
        instance = this;
        
    }

    #endregion

    public Transform BenchParent { get; private set; }
    public Transform StreetLightParent { get; private set; }
    public Transform TrashCanParent { get; private set; }
    public Transform StoveParent { get; private set; }
    public Transform TreeParent { get; private set; }
    public Transform TilemapParent { get; private set; }
    public Transform ItemCardsSellParent { get; private set; }

    private void Start()
    {
        SetParents();
        
    }

    public void SetParents()
    {

        try
        {
            BenchParent = GameObject.FindGameObjectWithTag("Bench Parent").GetComponent<Transform>();
        }
        catch
        {
            //return;
        }
        try
        {
            StreetLightParent = GameObject.FindGameObjectWithTag("StreetLight Parent").GetComponent<Transform>();
        }
        catch
        {
            //return;
        }
        try
        {
            TreeParent = GameObject.FindGameObjectWithTag("Trees Parent").GetComponent<Transform>();
        }
        catch
        {
            //return;
        }
        try
        {
            TilemapParent = GameObject.FindGameObjectWithTag("TileMap Parent").GetComponent<Transform>();
        }
        catch
        {
            //return;
        }
        try
        {
            TrashCanParent = GameObject.FindGameObjectWithTag("TrashCans Parent").GetComponent<Transform>();
        }
        catch
        {
            //return;
        }
        try
        {
            ItemCardsSellParent = GameObject.FindGameObjectWithTag("ItemCardsSellParent").GetComponent<Transform>();
        }
        catch
        {
            //Debug.Log("ITEM CARD NOTFOUND");
            //return;
        }
    }
}
