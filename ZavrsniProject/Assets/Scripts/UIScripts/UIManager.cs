using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    // u ovoj skripti aktiviramo inventorymanager kada zelimo da se inventory prikaze (neki button u safe zoni?)
    private InventoryUIManager _inventoryUIManager;
    public InventoryUIManager InventoryUIManagerPrefab;

    public Button InventoryButton;

    private void Awake()
    {
        _inventoryUIManager = GetComponentInChildren<InventoryUIManager>();
        InventoryButton = FindObjectOfType<Button>();

        if (!_inventoryUIManager)
        {
          //  _inventoryUIManager = Instantiate(InventoryUIManagerPrefab, Vector3.zero, Quaternion.identity, transform);
        }
    }

    private void Update()
    {
        InventoryButton.onClick.AddListener(SetInventoryActive);
    }


    public void SetInventoryActive ()
    {
        _inventoryUIManager.GetComponentInChildren<InventoryUIManager>().gameObject.SetActive(true);
        Debug.Log("clicked");
    }
}
