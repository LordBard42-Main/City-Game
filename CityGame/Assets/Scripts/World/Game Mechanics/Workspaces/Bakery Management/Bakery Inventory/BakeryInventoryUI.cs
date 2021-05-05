using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryInventoryUI : InventoryUI
{

    protected new IEnumerator Start()
    {
        base.Start();

        yield return new WaitForSeconds(.1f);
        inventory = BakeryManager.instance.BakeryInventory;
        BakeryManager.instance.BakeryInventory.OnItemChangedCallback += UpdateUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        BakeryManager.instance.BakeryInventory.OnItemChangedCallback -= UpdateUI;
    }

}
