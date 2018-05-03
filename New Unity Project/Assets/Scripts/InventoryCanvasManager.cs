using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryCanvasManager : MonoBehaviour
{

    public Inventory PlayerInventory;
    public InventorySlot InventorySlotPrefab;
    public Transform InventoryPanel;

    [Header("Read Only")]
    [SerializeField]
    private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

    private void Awake()
    {
        CreateInventorySlots();
        UpdateInventoryCanvas();

        PlayerInventory.OnInventoryChanged.AddListener(UpdateInventoryCanvas);
    }

    private void CreateInventorySlots()
    {
        for (int i = 0; i < PlayerInventory.Size; i++)
        {
            InventorySlot inventorySlotClone = Instantiate(InventorySlotPrefab, InventoryPanel);
            inventorySlotClone.ClearSlot();

            _inventorySlots.Add(inventorySlotClone);
        }
    }

    private void UpdateInventoryCanvas ()
    {
        for (int i = 0; i < _inventorySlots.Count; i++)
        {
            if (i < PlayerInventory.Items.Count)
            {
                _inventorySlots[i].AddSlotItem(PlayerInventory.Items[i]);
            }
            else
            {
                _inventorySlots[i].ClearSlot();
            }
        }
    }

}
