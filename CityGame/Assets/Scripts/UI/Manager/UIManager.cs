using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIManager
{

    [SerializeField] private UIController pauseMenuUI;

    [SerializeField] private UIController inventoryUI;

    [SerializeField] private UIController dialogueUI;

    public UIController PauseMenuUI { get => pauseMenuUI; private set => pauseMenuUI = value; }
    public UIController InventoryUI { get => inventoryUI; set => inventoryUI = value; }
    public UIController DialogueUI { get => dialogueUI; set => dialogueUI = value; }
}
