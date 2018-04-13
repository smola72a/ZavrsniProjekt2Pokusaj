using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{

    public HealthManager healthManager;
    private SOItem _playerWeapon;
    private SOItem _playerArmor;
    private SOEnemy _enemy;

    public bool BothAlive;

    public float WaitTimeBetweenAttacks;

    public bool EnemyIsStunned;
    public bool PlayerIsStunned;
    public float EnemyStunnedDuration;
    public float PlayerStunnedDuration;

    private bool _stopPlayerAttCoroutine;
    private bool _stopEnemyAttCoroutine;

    private float randomStunChanceNumber;

    EnemyType enemyType;
   
    /*
    void ngff()
    {
        randomStunChanceNumber = Random.Range(0, 10);

        if (randomStunChanceNumber <= _playerWeapon.StunChance) ;
    }
    */
    public void Awake()
    {
        GameManager.onBattlePhase.AddListener(Battle);
        
        _playerWeapon = GameManager.gm.PlayerWeapon;
        _playerArmor = GameManager.gm.PlayerArmor;
        WaitTimeBetweenAttacks = _playerWeapon.AttackSpeed / 10f * Time.deltaTime;
    }

    private void Update()
    {
        if (PlayerIsStunned)
        {

            PlayerStunnedDuration += Time.deltaTime;
            if (!_stopPlayerAttCoroutine)
            {
                StopCoroutine("PlayerAttacking");
                _stopPlayerAttCoroutine = true;
            }
           

            if (PlayerStunnedDuration >= _enemy.StunDuration)
            {
                StartCoroutine("PlayerAttacking");
                PlayerStunnedDuration = 0;
                PlayerIsStunned = false;
            }
        }

        if (EnemyIsStunned)
        {
            EnemyStunnedDuration += Time.deltaTime;
            
            if (!_stopEnemyAttCoroutine)
            {
                StopCoroutine("EnemyAttacking");
                _stopEnemyAttCoroutine = true;
            }
           
            if (EnemyStunnedDuration >= _playerWeapon.StunDuration)
            {
                StartCoroutine("EnemyAttacking");
                EnemyStunnedDuration = 0;
                EnemyIsStunned = false;
            }
        }
    }

    private void Battle(SOEnemy enemy)
    {
        _enemy = enemy;
        _stopEnemyAttCoroutine = false;
        _stopPlayerAttCoroutine = false;
        StartCoroutine(PlayerAttacking (_enemy));
        StartCoroutine(EnemyAttacking (_enemy));
    }

    private IEnumerator PlayerAttacking(SOEnemy enemy)
    {

        while (BothAlive && !PlayerIsStunned)
        {
        
            yield return new WaitForSeconds(WaitTimeBetweenAttacks);


            

            if (enemy.enemyType == _playerWeapon.VsType) 
            {
                healthManager.EnemyLoseHealth(enemy, _playerWeapon.AdditionalDamage);
            }
            else
            {
                healthManager.EnemyLoseHealth(enemy, _playerWeapon.Damage);
            }

            if (randomStunChanceNumber <= _playerWeapon.StunChance)
            {
                EnemyIsStunned = true;
            }
        }

    }


    private IEnumerator EnemyAttacking(SOEnemy enemy)
    {

        WaitTimeBetweenAttacks = enemy.AttackSpeed / 10.0f * Time.deltaTime;

		
        while (BothAlive && !EnemyIsStunned)
        {
            
            yield return new WaitForSeconds(WaitTimeBetweenAttacks);
            

            if (enemy.enemyType == _playerArmor.ProtectionType)
            {
                healthManager.PlayerLoseAdditionalArmor(enemy.Damage * enemy.DamagePerLevel);
            }
            else
            {
                healthManager.PlayerLoseHealth(enemy.Damage * enemy.DamagePerLevel);
            }

           

            if (randomStunChanceNumber <= _enemy.StunChance) 
            {
                PlayerIsStunned = true; //coroutina
            }








        }
    }
}



