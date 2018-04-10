using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnBattlePhase : UnityEvent<SOEnemy> { }

//TODO: Treba stavit enum za phase, i onda ga prek switcha mjenjat i slat eventove kad se promijeni, a promjenu primat od nekog drugog 
//(npr. Battle phase počinje on collision sa enemy i onda to pokrene gamemanager i promijeni enum u battlephase koji se onda šalje dalje)

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
//se moze koristiti samo enemytype bez damage type?
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
    public static OnBattlePhase onBattlePhase = new OnBattlePhase();

    public GameplayPhase gameplayPhase;
    public DamageType damageType;

   
   
	public LevelScaling levelScaling;
    public SOItem PlayerWeapon; //
    
   
    private int _playerDamage;
    private int _additionalDamage;

    public int Gold;
    public int ItemLevel;
    

    private bool _goldTransactionIsValid;
    private SOEnemy _enemy;
    private BattleManager _battleManager;


    void Awake()
    {
       
        switch (gameplayPhase)
        {
            case GameplayPhase.Battle:
                onBattlePhase.Invoke(_enemy); ////trebas mi objasniti sta smo tocno dobili s time
            

                break;
            case GameplayPhase.Choosing:
                break;
            case GameplayPhase.Camp:
                break;
           
        }

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


    
	
}
