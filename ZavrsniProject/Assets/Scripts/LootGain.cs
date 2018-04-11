using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemIsPickedUp : UnityEvent<SOItem> { }

public class LootGain : MonoBehaviour {



    //TODO: ovo se sve stavi na igrača pa imaš reference ko čovjek
   
    public static ItemIsPickedUp itemIsPickedUp = new ItemIsPickedUp();

    public SOItem [] ItemsAbleToGet;
    public SOEnemy DefeatedEnemy;
    public LootType lootType;

    public int GoldPerEnemyLvlMin;
    public int GoldPerEnemyLvlMax;

    private int _itemIndex;

    private Inventory inventory;

    public void ChoosingGold (SOEnemy defeatedEnemy)
    {
        int amountOfLoot = defeatedEnemy.Level * Random.Range(GoldPerEnemyLvlMin, GoldPerEnemyLvlMax);
        GameManager.gm.ChangeNumberOfGold(amountOfLoot);
    }

    public void ChoosingItem (SOEnemy defeatedEnemy)
    {
        _itemIndex = Random.Range(0, ItemsAbleToGet.Length);
        //
        SOItem newItem = ScriptableObject.Instantiate(ItemsAbleToGet[_itemIndex]) as SOItem;
        inventory.AddItemInInventory(newItem);
    }


}
