using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SOItem> ItemsInInventory = new List<SOItem>();

	//TODO: treba li ti zaista uopće ova lista
    public List<Vector2> ItemsOnSlot = new List<Vector2>();

	//TODO: jel ti ovo treba?
    public int StorageInInventory;

	//TODO: možeš napravit bez ove dvije. NumOfItemsInInventory ti je ItemsInInventory.Count, a InventoryIndex ti ni ne treba tj možeš ga izvuć isto iz liste
    private int NumOfItemsInInventory;
    public int InventoryIndex;

    private void Awake()
    {
        //TODO: više nemaš razliku između weapon i item tak da stavi additemininventory
        LootGain.itemIsPickedUp.AddListener(AddWeaponInInventory);
    }

    public void AddItemInInventory(SOItem ItemToAdd)
    {
        if (NumOfItemsInInventory < 6)
        {
			//TODO: kuiš onda ti ni ovo ne treba
            Vector2 Vektor = new Vector2(NumOfItemsInInventory, InventoryIndex);
            ItemsOnSlot.Add(Vektor);
            ItemsInInventory. Add(ItemToAdd);
            NumOfItemsInInventory++;
        }
    }

	//TODO:ovo se može ovak radit al može se vjv i prek indexa, tak da vidi kaj ti je zgodnije. Možda će ti bit lakše pristupit itemu prek indexa, a možda prek itema.
    public void RemoveItemFromInventory (SOItem ItemToRemove)
    {
		//TODO: treba vidjet kak se ponašaju ostali itemi u listi, tj dal se smanjuje ukupna veličina liste ili ostaje ista al je onda jedno mjesto prazno itd itd
        ItemsInInventory.Remove(ItemToRemove);
        NumOfItemsInInventory--;
    }


}
