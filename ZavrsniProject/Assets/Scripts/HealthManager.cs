using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int MaxHealth;
    public int MaxArmor;


    private int _health;
    private int _armor;

    public void RestoreHealth()
    {
        _health = MaxHealth;
    }

    public void RestoreArmor()
    {
        _armor = MaxArmor;
    }

    public void PlayerLoseHealth(int amount)
    {
        if (_armor <= 0)
        
            _health -= amount;
        
        else
        
            _armor -= amount;
        
       
        if (_health <= 0)
        
            Debug.Log("Player umire");
        
    }

    public void EnemyLoseHealth(SOEnemy enemy, int amount)
    {
        enemy.Health -= amount;
        if (enemy.Health <= 0)
        {
            Debug.Log("Enemy umire");
        }
    }

    // additional damage, prvo se treba armor trositi,

}
