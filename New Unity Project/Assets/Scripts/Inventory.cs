using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]

 public class Inventory 
{
    public int Size = 25;

    public List<Item> Items = new List<Item>();

    public UnityEvent OnInventoryChanged = new UnityEvent();

    public void AddItem(Item item)
    {
        if (Items.Count >= Size) 
        {
            Debug.Log("Inventory is Full");
        }
        else
        {
            Items.Add(item);
            OnInventoryChanged.Invoke();
        }
    }

    public void RemoveItem (Item item)
    {
        if (Items.Remove(item))
        OnInventoryChanged.Invoke();
    }
	
}
