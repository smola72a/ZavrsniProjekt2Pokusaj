using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIsPickedUp : UnityEvent<SOItem> { }

public class LootGain : MonoBehaviour {

   
    public static ItemIsPickedUp itemIsPickedUp = new ItemIsPickedUp();

    public SOItem [] ItemsAbleToGet;
    public SOEnemy DefeatedEnemy;

    public int GoldPerEnemyLvlMin;
    public int GoldPerEnemyLvlMax;

    private int _itemIndex;

    public void ChoosingGold (SOEnemy defeatedEnemy)
    {
        int amountOfLoot = defeatedEnemy.Level * Random.Range(GoldPerEnemyLvlMin, GoldPerEnemyLvlMax);
        GameManager.gm.ChangeNumberOfGold(amountOfLoot);
    }

    public void ChoosingItem (SOEnemy defeatedEnemy)
    {
        _itemIndex = Random.Range(0, ItemsAbleToGet.Length);
        ScriptableObject.Instantiate(ItemsAbleToGet[_itemIndex]);
    }


}
