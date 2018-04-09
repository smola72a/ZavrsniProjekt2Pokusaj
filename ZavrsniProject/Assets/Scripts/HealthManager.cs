using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int MaxHealth;


    private int _health;

    public void RestoreHealth()
    {
        _health = MaxHealth;
    }

    public void PlayerLoseHealth(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Debug.Log("Player umire");
        }
    }

    public void EnemyLoseHealth(SOEnemy enemy, Vector2 amount)
    {
        enemy.Health -= (int) amount;
        if (enemy.Health <= 0)
        {
            Debug.Log("Enemy umire");
        }
    }

}
