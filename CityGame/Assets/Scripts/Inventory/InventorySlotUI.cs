using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [Header("UI Data")]

    [SerializeField] private Image icon;
    [SerializeField] private Text itemNameText;
    [SerializeField] private Text itemCountText;
    [SerializeField] private Text itemCostText;

    public Text ItemName { get => itemNameText; set => itemNameText = value; }
    public Text ItemCountText { get => itemCountText; set => itemCountText = value; }
    public Text ItemCostText { get => itemCostText; set => itemCostText = value; }
    
    public void SetSlotUI(InventorySlotData slotData)
    {
        if(slotData.IsEmpty)
        {
            ClearSlotUI();
        }
        else
        {
            icon.sprite = slotData.Item.Icon;
            icon.enabled = true;

            itemNameText.text = slotData.Item.name;
            itemCountText.text = slotData.Count + "";
            itemCountText.enabled = true;
            itemCostText.text = slotData.Price + "";

        }
    }

    private void ClearSlotUI()
    {
        icon.sprite = null;
        icon.enabled = false;
        itemCountText.enabled = false;

        itemNameText.text = "";
        itemCountText.text = "";
        itemCostText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
