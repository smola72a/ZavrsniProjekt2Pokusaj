using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    Inventory inventory;

    public List<Image> InventorySlots = new List<Image>();
    public Sprite EmptySlot;

    private void Awake()
    {
        inventory.OnInventoryChanged.AddListener(RefreshInventory);
        RefreshInventory(inventory);
    }

    private void RefreshInventory (Inventory inventory)
    {
        
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                
            if (i < inventory.ItemsInInventory.Count )
            {
                InventorySlots[i].sprite = inventory.ItemsInInventory[i].Icon;
            }
            else
            {
                InventorySlots[i].sprite = null;
            }

            }
      
       
    }

}
