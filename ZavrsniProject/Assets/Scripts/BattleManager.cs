using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{

    public HealthManager healthManager;
    private SOItem _playerWeapon;
    private SOEnemy _enemy;

    public bool BothAlive;

    public float WaitTimeBetweenAttacks;

    public bool EnemyIsStunned;
    public bool PlayerIsStunned;
    public float EnemyStunnedDuration;
    public float PlayerStunnedDuration;

    private bool _stopAttCoroutine;

    EnemyType enemyType;
    DamageType damageType;



    public void Awake()
    {
        GameManager.onBattlePhase.AddListener(Battle);
        _playerWeapon = GameManager.gm.PlayerWeapon;
        WaitTimeBetweenAttacks = _playerWeapon.AttackSpeed / 10f * Time.deltaTime;
    }

    private void Update()
    {
        if (PlayerIsStunned)
        {

            PlayerStunnedDuration += Time.deltaTime;
            if (!_stopAttCoroutine)
            {
                StopCoroutine("PlayerAttacking");
                _stopAttCoroutine = true;
            }
            //TODO:

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
            //TODO: 
            if (!_stopAttCoroutine)
            {
                StopCoroutine("EnemyAttacking");
                _stopAttCoroutine = true;
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
        StartCoroutine("PlayerAttacking");
        StartCoroutine("EnemyAttacking");
    }

    private IEnumerator PlayerAttacking(SOEnemy enemy)
    {

        while (BothAlive && !PlayerIsStunned)
        {
            yield return new WaitForSeconds(WaitTimeBetweenAttacks);
            if (enemy.enemyType == EnemyType.Bandits && _playerWeapon.VsType == DamageType.DmgBandits) ////hahahah moram postojat bolji nacin...
            {

            }
            healthManager.EnemyLoseHealth(enemy, _playerWeapon.Damage);
            if (_playerWeapon.ShouldStun)
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
            //promjeniti damage za playera
            healthManager.PlayerLoseHealth(enemy.Damage * enemy.DamagePerLevel);

            if (enemy.ShouldStun)
            {
                PlayerIsStunned = true;
            }








        }
    }
}



