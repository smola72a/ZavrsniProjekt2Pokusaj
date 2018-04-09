using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SOItem> ItemsInInventory = new List<SOItem>();

    public List<Vector2> ItemsOnSlot = new List<Vector2>();

    public int StorageInInventory;

    private int NumOfItemsInInventory;
    public int InventoryIndex;

    private void Awake()
    {
        
        LootGain.itemIsPickedUp.AddListener(AddWeaponInInventory);
    }

    public void AddItemInInventory(SOItem ItemToAdd)
    {
        if (NumOfItemsInInventory < 6)
        {
            Vector2 Vektor = new Vector2(NumOfItemsInInventory, InventoryIndex);
            ItemsOnSlot.Add(Vektor);
            ItemsInInventory. Add(ItemToAdd);
            NumOfItemsInInventory++;
        }
    }

    public void RemoveItemFromInventory (SOItem ItemToRemove)
    {
        ItemsInInventory.Remove(ItemToRemove);
        NumOfItemsInInventory--;
    }


}
