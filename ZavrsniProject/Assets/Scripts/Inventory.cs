using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    public class CustomEvent<Inventory> : UnityEvent<Inventory> { }
  
    public List<SOItem> ItemsInInventory = new List<SOItem>();

    private int Size = 6;






    private void Awake()
    {
        
        LootGain.itemIsPickedUp.AddListener(AddItemInInventory);
    }

    public void AddItemInInventory(SOItem ItemToAdd)
    {
        {
            if (ItemsInInventory.Count < Size)
            {

                ItemsInInventory.Add(ItemToAdd);
                
            }
            else
            {
                Debug.Log("Inventory is full");
                
            }
        }
    }

	
    public void RemoveItemFromInventory (SOItem ItemToRemove)
    {
		
        ItemsInInventory.Remove(ItemToRemove);
     
        for (int i = 0; i < ItemsInInventory.Count; i++)
            {
                if (ItemsInInventory[i] == ItemToRemove)
                {
                    ItemsInInventory[i] = null;
                   
                   
                }
            }
        }

}



