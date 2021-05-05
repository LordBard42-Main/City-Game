using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Stores Prefabs that I can instantiate through scripts
/// </summary>
public class PrefabManager : MonoBehaviour
{
    #region  Singleton

    public static PrefabManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("PrefabManager already exists");
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] private ConsumablePrefabHolder consumables;
    [SerializeField] private InteractablePrefabsHolder interactables;
    [SerializeField] private UIPrefabHolder ui;



   


    public ConsumablePrefabHolder Consumables { get => consumables; set => consumables = value; }
    public InteractablePrefabsHolder Interactables { get => interactables; set => interactables = value; }
    public UIPrefabHolder UI { get => ui; set => ui = value; }
}

