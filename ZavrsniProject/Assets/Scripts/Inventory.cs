using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory : MonoBehaviour
{

    public class CustomEvent<Inventory> : UnityEvent<Inventory> { }
    public int Size = 6;
    public List<SOItem> ItemsInInventory = new List<SOItem>();
    public CustomEvent<Inventory> OnInventoryChanged = new CustomEvent<Inventory>();
    


    //TODO: možeš napravit bez ove dvije. NumOfItemsInInventory ti je ItemsInInventory.Count, a InventoryIndex ti ni ne treba tj možeš ga izvuć isto iz liste
    //private int NumOfItemsInInventory;
    //public int InventoryIndex;

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
                OnInventoryChanged.Invoke(this);
               
            }
            else
            {
                Debug.Log("Inventory is full");
                
            }
        }
    }

	//TODO:ovo se može ovak radit al može se vjv i prek indexa, tak da vidi kaj ti je zgodnije. Možda će ti bit lakše pristupit itemu prek indexa, a možda prek itema.
    public void RemoveItemFromInventory (SOItem ItemToRemove)
    {
		//TODO: treba vidjet kak se ponašaju ostali itemi u listi, tj dal se smanjuje ukupna veličina liste ili ostaje ista al je onda jedno mjesto prazno itd itd
        ItemsInInventory.Remove(ItemToRemove);
        OnInventoryChanged.Invoke(this);
       
    }


}
