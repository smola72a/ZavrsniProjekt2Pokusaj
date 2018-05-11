using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnBattlePhase : UnityEvent  { }
public class OnChoosingPhase : UnityEvent { }







public enum GameplayPhase
{
    Battle,
    Choosing,
    Camp,
    Loot
    
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
    public static OnChoosingPhase onChoosingPhase = new OnChoosingPhase();
   
    public GameplayPhase gameplayPhase;

	public LevelScaling levelScaling;

    public SOEnemy LeftEnemy;
    public SOEnemy RightEnemy;

    public int NumOfEnemies;


    //univerzalno?
    private int _playerDamage;
    private int _additionalDamage;

    private HealthManager healthManager;
    public int Gold;

    private bool _goldTransactionIsValid;

    public void Awake()
    {
        SwitchedPhase(GameplayPhase.Battle);
        gm = this;
        healthManager = GetComponent<HealthManager>();
    }


    public void SwitchedPhase(GameplayPhase phase)
    {
        gameplayPhase = phase;

        switch (gameplayPhase)
        {
            //ova faza počinje kolizijom
            case GameplayPhase.Battle:
                GenerateStartingItems();
                GenerateEnemy();
                onBattlePhase.Invoke(); 
                break;
                
            //ova faza počinje nakon kaj izađeš iz kampa ili kombata
            case GameplayPhase.Choosing:
                onChoosingPhase.Invoke();

                GenerateEnemy();
               

                break;
            //nakon kaj se ispune uvjeti za finish borbe
            case GameplayPhase.Camp:
                Camp();
                break;
               

            case GameplayPhase.Loot:
                GenerateLootItems();
                break;

            
        }
    }

   public void GenerateEnemy()
    {
        SOEnemy rightEnemy = ScriptableObject.Instantiate(Pool.pool.AllEnemiesPrefabs[Random.Range(0, Pool.pool.AllEnemiesPrefabs.Count)]);
        SOEnemy leftEnemy = ScriptableObject.Instantiate(Pool.pool.AllEnemiesPrefabs[Random.Range(0, Pool.pool.AllEnemiesPrefabs.Count)]);

        rightEnemy.AttackSpeed += rightEnemy.AttackSpeed + rightEnemy.AttackSpeedPerLevel * (float)Pool.pool.EnemyLevel;
        rightEnemy.Damage += rightEnemy.Damage + rightEnemy.DamagePerLevel * Pool.pool.EnemyLevel;
        rightEnemy.Health += rightEnemy.Health + rightEnemy.HealthPerLevel * Pool.pool.EnemyLevel;

        leftEnemy.AttackSpeed += leftEnemy.AttackSpeed + leftEnemy.AttackSpeedPerLevel * Pool.pool.EnemyLevel;
        leftEnemy.Damage += leftEnemy.Damage + leftEnemy.DamagePerLevel * Pool.pool.EnemyLevel;
        leftEnemy.Health += leftEnemy.Health + leftEnemy.HealthPerLevel * Pool.pool.EnemyLevel;

        rightEnemy = RightEnemy;
        leftEnemy = LeftEnemy;

        Pool.pool.EnemyInBattle = RightEnemy;
       


    }

    public void UpgradeItem(SOItem ItemOnPlayerToUpgrade)
    {
        ChangeNumberOfGold(-ItemOnPlayerToUpgrade.UpgradeCost);
        if (_goldTransactionIsValid)
        {
            ItemOnPlayerToUpgrade.Level++;
            ////ItemLevel++; dali onda tu mjenjamo Item level ili u SOItem?

            //mora bit weapon
            levelScaling.UpgradeWeapon(ItemOnPlayerToUpgrade);
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
        SOItem Weapon = ScriptableObject.Instantiate(Pool.pool.AllWeaponsPrefabs[Random.Range(0, Pool.pool.AllWeaponsPrefabs.Count)]);
        SOItem armor = ScriptableObject.Instantiate(Pool.pool.AllArmorsPrefabs[Random.Range(0, Pool.pool.AllArmorsPrefabs.Count)]);

        Pool.pool.WeaponOnPlayer = Weapon;
        Pool.pool.ArmorOnPlayer = armor;

    }

    public void GenerateLootItems()
    {

        SOItem Item = ScriptableObject.Instantiate(Pool.pool.AllItemsPrefabs[Random.Range(0, Pool.pool.AllItemsPrefabs.Count)]);
        Item.Level = Random.Range(0, Item.MaxLevel);

        if (NumOfEnemies == 0)
        {
            SwitchedPhase(GameplayPhase.Camp);
        }
        else
        {
            SwitchedPhase(GameplayPhase.Choosing);
        }
       
        
    }

    private void Camp ()
    {


        NumOfEnemies = 5;
        healthManager.RestoreHealth();
        healthManager.RestoreArmor(); //
        Pool.pool.EnemyLevel++;

        DefineMinLevel();


        //Canvas za camp

    }

    private void DefineMinLevel ()
    {
        if (Pool.pool.EnemyLevel <= 5)
        {
            Pool.pool.ItemMinLevel = 0;
        }
        else
        {
            Pool.pool.ItemMinLevel = Pool.pool.EnemyLevel - 5;
        }
    }

    

    


}
      


