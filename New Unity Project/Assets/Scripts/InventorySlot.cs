using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item SlotItem;

    [Header("Slot Properties")]
    public Button UseButton;
    public Button DropButton;
    public Button SellButton;

    private void Awake()
    {
        UseButton.onClick.AddListener(UseSlotItem);
        UseButton.interactable = true;
        DropButton.interactable = true;
        SellButton.interactable = true;
    }

    public void AddSlotItem (Item slotItem)
    {
        SlotItem = slotItem;

        UseButton.image.sprite = SlotItem.Icon;
        UseButton.interactable = false;
        DropButton.interactable = false;
        SellButton.interactable = false;
    }

    public void ClearSlot ()
    {
        SlotItem = null;

        UseButton.image.sprite = null;
    }

    public void UseSlotItem ()
    {
        Debug.Log("log");
    }

    public void DropSlotItem()
    {
        Debug.Log("drop");
    }

    public void SellSlotItem()
    {
        Debug.Log("sell");
    }

}
