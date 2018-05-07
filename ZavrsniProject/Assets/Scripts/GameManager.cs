using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class OnBattlePhase : UnityEvent { }


public enum GameplayPhase
{
    Battle,
    Choosing,
    Camp
}

public enum ItemType
{
    Weapon,
    Armor
}

public enum EnemyType
{
    Bandits,
    Wildlife,
    Imps,
    Skeletons
}



public enum LootType
{
    Gold,
    Item
}



public class GameManager : MonoBehaviour {

    public static GameManager gm;
    public static OnBattlePhase onBattlePhase = new OnBattlePhase();

    public GameplayPhase gameplayPhase;

	public LevelScaling levelScaling;


    //univerzalno?
    private int _playerDamage;
    private int _additionalDamage;

    public int Gold;

    private bool _goldTransactionIsValid;

   public void SwitchedPhase(GameplayPhase phase)
    {
        gameplayPhase = phase;

        switch (gameplayPhase)
        {
            //ova faza počinje kolizijom
            case GameplayPhase.Battle:
                //ne ovdje neg kad se bira put (prije Chosing)
                GenerateStartingItems();
                //GenerateEnemy();
                Debug.Log("ha");
                onBattlePhase.Invoke(); ////trebas mi objasniti sta smo tocno dobili s time
                
                break;
            //ova faza počinje nakon kaj izađeš iz kampa ili kombata
            case GameplayPhase.Choosing:
                //ovdje negdje treba bit taj generirani protivnik
                break;
            //nakon kaj se ispune uvjeti za finish borbe
            case GameplayPhase.Camp:
                break;
        }
    }

   public void GenerateEnemy()
    {
        //trebat će enemyClone još dodat određene vrijednosti i treba se poredat ostale vrijednosti s levelom
         Pool.pool.EnemyInBattle =  ScriptableObject.Instantiate (Pool.pool.AllEnemiesPrefabs[Random.Range(0, Pool.pool.AllEnemiesPrefabs.Count)]); 
    }

    public void UpgradeItem(SOItem ItemOnPlayerToUpgrade)
    {
        ChangeNumberOfGold(-ItemOnPlayerToUpgrade.UpgradeCost);
        if (_goldTransactionIsValid)
        {
            ItemOnPlayerToUpgrade.Level++;
            ////ItemLevel++; dali onda tu mjenjamo Item level ili u SOItem?
            levelScaling.UpgradeItem(ItemOnPlayerToUpgrade);
        }
    }

    public void ChangeNumberOfGold (int amount)
    {
        if (Gold + amount >= 0)
        {
            Gold += amount;
            _goldTransactionIsValid = true;
        }
        else
        {
            _goldTransactionIsValid = false;
        }
    }
    /*
    public void CheckItemType (SOItem ItemToCheck)
    {
        if (ItemToCheck.itemType == ItemType.Weapon)
        {
            PlayerWeapon = ItemToCheck;
        }
        else
        {
            PlayerArmor = ItemToCheck;
        }
    }
    */

        private void GenerateStartingItems()
    {
        //SOItem item = Instantiate(Pool.pool.AllWeaponsPrefabs[Random.Range(0, Pool.pool.AllWeaponsPrefabs.Count)]);
        SOItem armor = ScriptableObject.Instantiate(Pool.pool.AllArmorsPrefabs[Random.Range(0, Pool.pool.AllArmorsPrefabs.Count)]);

        //Pool.pool.WeaponOnPlayer = item;
        Pool.pool.ArmorOnPlayer = armor;

    }

    public void Awake()
    {
        SwitchedPhase(GameplayPhase.Battle);
    }

}
