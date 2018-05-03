using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Item SlotItem;

    [Header("Slot Properties")]
    public Button BuyButton;
    public Image Icon;

    public void AddSlotItem(Item slotItem)
    {
        slotItem = SlotItem;

        Icon.sprite = slotItem.Icon;
        BuyButton.interactable = true;
    }
	
    public void ClearSlot()
    {
        SlotItem = null;

        Icon.sprite = null;
        BuyButton.interactable = false;
    }

    public void BuySlotItem ()
    {
        Debug.Log("buy item");
    }
}
