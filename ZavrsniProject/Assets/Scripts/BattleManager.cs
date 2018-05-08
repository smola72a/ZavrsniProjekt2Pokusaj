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

    EnemyType enemyType;
   
   
    public void Awake()
    {

        GameManager.onBattlePhase.AddListener(Battle);
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
           
            if (EnemyStunnedDuration >= _playerWeapon.StunDuration)
            {
                StartCoroutine(EnemyAttacking(_enemy));
                EnemyStunnedDuration = 0;
                EnemyIsStunned = false;
            }
        }
    }

    private void Battle()
    {

        _playerWeapon = Pool.pool.WeaponOnPlayer;
        _playerArmor = Pool.pool.ArmorOnPlayer;

        //TODO:ovo ćemo mijenjat
        //WaitTimeBetweenAttacks = 10f/_playerWeapon.AttackSpeed * Time.deltaTime;

        _enemy = Pool.pool.EnemyInBattle;
        _stopEnemyAttCoroutine = false;
        _stopPlayerAttCoroutine = false;
        StartCoroutine(PlayerAttacking (_enemy));
        StartCoroutine(EnemyAttacking (_enemy));
    }

    private IEnumerator PlayerAttacking(SOEnemy enemy)
    {
<<<<<<< HEAD
=======
       
>>>>>>> 6bc2285ecf805507df6300eb2817a802b55e4054

        while (BothAlive && !PlayerIsStunned)
        {
        
            yield return new WaitForSeconds(WaitTimeBetweenAttacks);

            int damage = ReturnPlayerDamage();
            int additionalDamage = ReturnPlayerAdditionalDamage();

            StunChanceNumber(); 

            if (enemy.enemyType == _playerWeapon.VsType) 
            {
                healthManager.EnemyLoseHealth(enemy, additionalDamage);
            }
            else
            {
                healthManager.EnemyLoseHealth(enemy, damage);
            }

            if (_randomStunChanceNumber <= _playerWeapon.StunChance)
            {
                EnemyIsStunned = true;
            }
            else
            {
                EnemyIsStunned = false;
            }
        }

    }


    private IEnumerator EnemyAttacking(SOEnemy enemy)
    {

        //TODO: ne uzimat attack speed neg neš kaj je izračunato sa attackspeed*attackspeedperlevel
        //WaitTimeBetweenAttacks = enemy.AttackSpeed / 10.0f * Time.deltaTime;

        StunChanceNumber();

        while (BothAlive && !EnemyIsStunned)
        {

            yield return new WaitForSeconds(WaitTimeBetweenAttacks);
            int damage = ReturnEnemyDamage();


            if (enemy.enemyType == _playerArmor.ProtectionType)
            {
                healthManager.PlayerLoseAdditionalArmor(damage);
            }
            else
            {
                healthManager.PlayerLoseHealth(damage);
            }



            if (_randomStunChanceNumber <= _enemy.StunChance)
            {
               PlayerIsStunned = true; 
            }
            else
            {
                PlayerIsStunned = false;
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




