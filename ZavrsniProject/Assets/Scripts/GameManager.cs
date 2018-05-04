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
    public SOEnemy _enemy;


    private int _playerDamage;
    private int _additionalDamage;

    public int Gold;
    public int ItemLevel;

    public List<SOEnemy> EnemyPrefabs = new List<SOEnemy>(); 
    private bool _goldTransactionIsValid;
    
    private BattleManager _battleManager;


   public void Update()
    {
        switch (gameplayPhase)
        {
            //ova faza počinje kolizijom
            case GameplayPhase.Battle:
                //ne ovdje neg kad se bira put (prije Chosing)
               // GenerateEnemy();
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

   public void GenerateEnemy()
    {
        //trebat će enemyClone još dodat određene vrijednosti i treba se poredat ostale vrijednosti s levelom
        SOEnemy _enemyClone = ScriptableObject.Instantiate (EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)]); //
        _enemyClone = _enemy;
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

 //[CustomEditor(typeof(GameManager))]
 //public class GameManagerEditor : Editor
 //{
 //    public  void  GenerateEnemy()
 //    {
 //       
 //        base.OnInspectorGUI();
 //
 //        GameManager gameManager = (GameManager)target;
 //
 //        if (GUILayout.Button ("Activate"))
 //        {
 //           gameManager.GenerateEnemy();
 //           GameManager.onBattlePhase.Invoke(GameManager.gm._enemy);
 //        }
 //
 //      
 //    }
 //}


    //ovdje editor
    //on gui il kaj god ćeš generirat protivnika i onda invoke onbattlephase
	
}
