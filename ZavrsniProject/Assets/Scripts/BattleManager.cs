using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{

    public HealthManager healthManager;
    public SOItem _playerWeapon;
    public SOItem _playerArmor;
    public SOEnemy _enemy;

    public bool BothAlive;

    public float WaitTimeBetweenAttacks;

    public bool EnemyIsStunned;
    public bool PlayerIsStunned;

    public bool PlayerAttacks;
    public bool EnemyAttacks;

    private bool _shouldBattle = false;

    private bool _stopPlayerAttCoroutine;
    private bool _stopEnemyAttCoroutine;

    private float PlayerAttackWait;
    private float EnemyAttackWait;

    private float PlayerStunDuration;
    private float EnemyStunDuration;

    private float _randomStunChanceNumber;

    private ShowDamage showDamage;
  

    EnemyType enemyType;
   
   
    public void Awake()
    {

        GameManager.onBattlePhase.AddListener(Battle);
        showDamage = GetComponent<ShowDamage>();
    }

    private void Update()
    {
        if (_shouldBattle)
        {




            if (!PlayerIsStunned)
                PlayerAttackWait += Time.deltaTime;
            else
            {
                PlayerStunDuration += Time.deltaTime;
                if (PlayerStunDuration >= _enemy.StunDuration)
                {
                    PlayerIsStunned = false;
                    PlayerStunDuration = 0f;
                }
            }
            if (!EnemyIsStunned)
                EnemyAttackWait += Time.deltaTime;
            else
            {
                EnemyStunDuration += Time.deltaTime;
                if (EnemyStunDuration >= _playerWeapon.StunDuration)
                {
                    EnemyIsStunned = false;
                    EnemyStunDuration = 0f;
                }

            }



            if (PlayerAttackWait >= 100 / _playerWeapon.AttackSpeed)
            {
                PlayerAttacking(_enemy);
                PlayerAttackWait = 0f;

            }

            if (EnemyAttackWait >= 100 / _enemy.AttackSpeed)
            {
                EnemyAttacking(_enemy);
                EnemyAttackWait = 0f;
            }
        }


    }

    private void Battle()
    {

        _playerWeapon = Pool.pool.WeaponOnPlayer;
        _playerArmor = Pool.pool.ArmorOnPlayer;
        _enemy = Pool.pool.EnemyInBattle;

        _shouldBattle = true;
      

        
      
    }

    private void PlayerAttacking(SOEnemy enemy)
    {
        
            int damage = ReturnPlayerDamage();
            int additionalDamage = ReturnPlayerAdditionalDamage();

            if (enemy.enemyType == _playerWeapon.VsType) 
            {
               healthManager.EnemyLoseHealth(enemy, additionalDamage);
                showDamage.ShowEnemyDamage(additionalDamage);
            }
            else
            {
                healthManager.EnemyLoseHealth(enemy, damage);
            if (healthManager.EnemyDied)
            {
                OnBattleEnd();
            }
                showDamage.ShowEnemyDamage(damage);
            }
            if (_playerWeapon.ShouldStun)
            {
                StunChanceNumber();
                if (_randomStunChanceNumber <= _playerWeapon.StunChance)
                {
                    EnemyIsStunned = true;
                    Debug.Log("enemy stunned");
        
                }
            }
        }

        

    

   


    private void EnemyAttacking(SOEnemy enemy)
    {


            int damage = ReturnEnemyDamage();
            Debug.Log("nj2");

            if (enemy.enemyType == _playerArmor.ProtectionType)
            {
                healthManager.PlayerLoseAdditionalArmor(damage);
            }
            else
            {
                Debug.Log("nj3");
                healthManager.PlayerLoseHealth(damage);
            if (healthManager.PlayerDied)
            {
                _shouldBattle = false;
                Debug.Log("umro si frende");
            }
                showDamage.ShowPlayerDamage(damage);
            }


            if (enemy.ShouldStun)
            {
                StunChanceNumber();
                if (_randomStunChanceNumber <= _enemy.StunChance)
                {
                    PlayerIsStunned = true;
                }
           
            }
    }

   

    public void StunChanceNumber ()
    {
        _randomStunChanceNumber = Random.Range(0, 10);
    }

    private int ReturnPlayerDamage()
    {
        return Random.Range(_playerWeapon.Damage.x, _playerWeapon.Damage.y);
    }
    private int ReturnPlayerAdditionalDamage()
    {
        return Random.Range(_playerWeapon.AdditionalDamage.x, _playerWeapon.AdditionalDamage.y);
    }

    private int ReturnEnemyDamage()
    {
        return Random.Range(_enemy.Damage.x, _enemy.Damage.y);
    }

    public void LootDrop()
    {
        if (healthManager.EnemyDied == true)
        {
            GameManager.gm.GenerateLootItems();
        }
    }

    private void OnBattleEnd()
    {
        _shouldBattle = false;
        GameManager.gm.NumOfEnemies--;
        GameManager.gm.SwitchedPhase(GameplayPhase.Loot);

    }
    

}




           

