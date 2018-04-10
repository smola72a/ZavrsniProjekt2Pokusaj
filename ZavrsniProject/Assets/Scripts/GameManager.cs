using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: usingUnityEngine.Events treba stavit

public class OnBattlePhase : UnityEvent<SOEnemy> { }

//TODO: Treba stavit enum za phase, i onda ga prek switcha mjenjat i slat eventove kad se promijeni, a promjenu primat od nekog drugog 
//(npr. Battle phase počinje on collision sa enemy i onda to pokrene gamemanager i promijeni enum u battlephase koji se onda šalje dalje)

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
    //umjesto ovog imaš level na itemu
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
