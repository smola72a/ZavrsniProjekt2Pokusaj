using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnBattlePhase : UnityEvent<SOEnemy> { }


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
    public SOItem PlayerWeapon;
    public SOItem PlayerArmor;
    
   
    private int _playerDamage;
    private int _additionalDamage;

    public int Gold;
    public int ItemLevel;
    

    private bool _goldTransactionIsValid;
    private SOEnemy _enemy;
    private BattleManager _battleManager;


   private void Update()
    {
        switch (gameplayPhase)
        {
            //ova faza počinje kolizijom
            case GameplayPhase.Battle:
                onBattlePhase.Invoke(_enemy); ////trebas mi objasniti sta smo tocno dobili s time
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

    private void GenerateEnemy()
    {
        //iz liste koja sadržava SOEnemy prefabove, napravi se jedan, odredi mu se level (ak treba još neš), i onda ga se šalje dalje
    }

    public void UpgradeWeapon(SOItem ItemOnPlayerToUpgrade)
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


    
	
}
