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
    public float EnemyStunnedDuration;
    public float PlayerStunnedDuration;

    private bool _stopPlayerAttCoroutine;
    private bool _stopEnemyAttCoroutine;

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
        if (PlayerIsStunned)
        {

            PlayerStunnedDuration += Time.deltaTime;
            if (!_stopPlayerAttCoroutine)
            {
                StopCoroutine(PlayerAttacking(_enemy));
                _stopPlayerAttCoroutine = true;
            }
           

            if (PlayerStunnedDuration >= _enemy.StunDuration)
            {
                StartCoroutine(PlayerAttacking(_enemy));
                PlayerStunnedDuration = 0;
                PlayerIsStunned = false;
                _stopPlayerAttCoroutine = false;
            }
        }

        if (EnemyIsStunned)
        {
            EnemyStunnedDuration += Time.deltaTime;

            if (!_stopEnemyAttCoroutine)
            {
                StopCoroutine(EnemyAttacking(_enemy));
                _stopEnemyAttCoroutine = true;
            }
        }

        if (EnemyStunnedDuration > _playerWeapon.StunDuration)
        {
                StartCoroutine(EnemyAttacking(_enemy));
                EnemyStunnedDuration = 0;
                EnemyIsStunned = false;
                _stopEnemyAttCoroutine = false;
        }
        
    }

    private void Battle()
    {

        _playerWeapon = Pool.pool.WeaponOnPlayer;
        _playerArmor = Pool.pool.ArmorOnPlayer;

        //TODO:ovo ćemo mijenjat
        WaitTimeBetweenAttacks = (10000f / _playerWeapon.AttackSpeed) * Time.deltaTime;

        _enemy = Pool.pool.EnemyInBattle;
        _stopEnemyAttCoroutine = false;
        _stopPlayerAttCoroutine = false;
        StartCoroutine(PlayerAttacking (_enemy));
        StartCoroutine(EnemyAttacking (_enemy));
    }

    private IEnumerator PlayerAttacking(SOEnemy enemy)
    {

        while (BothAlive)
        {
        
            yield return new WaitForSeconds(WaitTimeBetweenAttacks);

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

    }


    private IEnumerator EnemyAttacking(SOEnemy enemy)
    {

        Debug.Log("krenula korutina");
        WaitTimeBetweenAttacks = (10000.0f / enemy.AttackSpeed ) * Time.deltaTime;

        //staviti korutine ovdje a ne update

        while (BothAlive)
        {
            Debug.Log("nj");

            yield return new WaitForSeconds(WaitTimeBetweenAttacks);
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
    

}




