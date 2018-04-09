using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    public void Awake()
    {
        GameManager.onBattlePhase.AddListener(battle);
        _playerWeapon = GameManager.gm.ItemOnPlayer;
        WaitTimeBetweenAttacks = _playerWeapon.AttackSpeed / 10f * Time.deltaTime;
    }

    private void Update()
    {
        if (PlayerIsStunned)
        {

            PlayerStunnedDuration += Time.deltaTime;
            StopCoroutine("PlayerAttacking");
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
            StopCoroutine("EnemyAttacking");
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

        while (BothAlive)
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



