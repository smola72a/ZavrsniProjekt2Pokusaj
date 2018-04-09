using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBattlePhase : UnityEvent<SOEnemy> { }


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

public enum DamageType
{
    DmgBandits,
    DmgWildlife,
    DmgImps,
    DmgSkeletons
}

public enum LootType
{
    Gold,
    Item
}

public class GameManager : MonoBehaviour {

    public static GameManager gm;
   // public static OnBattlePhase onBattlePhase = new OnBattlePhase();


    public SOItem ItemOnPlayer;
    public LevelScaling levelScaling;
   
    private int _playerDamage;

    public int Gold;
    public int ItemLevel;
    

    private bool GoldTransactionIsValid;

    void Awake()
    {
        //onBattlePhase.Invoke(enemy);
    }

    public void UpgradeWeapon(SOItem ItemOnPlayerToUpgrade)
    {
        ChangeNumberOfGold(-ItemOnPlayerToUpgrade.UpgradeCost);
        if (GoldTransactionIsValid)
        {
            ItemLevel++;
            levelScaling.UpgradeItem(ItemOnPlayerToUpgrade);
        }


    }

    public void ChangeNumberOfGold (int amount)
    {
        if (Gold + amount >= 0)
        {
            Gold += amount;
            GoldTransactionIsValid = true;
        }
        else
        {
            GoldTransactionIsValid = false;
        }
    }


    
	
}
