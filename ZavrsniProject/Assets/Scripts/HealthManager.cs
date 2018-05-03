using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public EnemyType ProtectionType = EnemyType.Bandits;

    public int MaxHealth;
    public int MaxArmor;
    public int MaxAdditionalArmor;

    private int _armor;
    private int _armorDamage;
    private int _damageLeft;

    private int _additionalArmor;
    private int _additionalArmorDamage;
    private int _additionalArmorDamageLeft;

    private int _health;
   
    

    public void RestoreHealth()
    {
        _health = MaxHealth;
    }

    public void RestoreArmor()
    {
        _armor = MaxArmor;
    }

    public void PlayerLoseAdditionalArmor(int amount)
    {
        if (_additionalArmor > 0)
        {
            _additionalArmorDamageLeft = 0;
            _additionalArmor -= amount;
            if (_additionalArmor < 0)
            {
                _additionalArmorDamageLeft -= _additionalArmor;
                _additionalArmor = 0;
            }
            if (_additionalArmorDamageLeft > 0)
            {
                PlayerLoseHealth(_additionalArmorDamageLeft);
            }
        }
        
      

    }


    public void PlayerLoseHealth(int amount)
    {


        if (_armor > 0)
        {

            _damageLeft = 0;
            _armor -= amount;
            if (_armor < 0)
            {
                _damageLeft -= _armor;
                _armor = 0;
            }

            if (_damageLeft > 0)
            {
                _health -= _damageLeft;
            }

            if (_health <= 0)

                Debug.Log("Player umire");
        }
    }


    public void EnemyLoseHealth(SOEnemy enemy, int amount)
    {
        enemy.Health -= amount;
        if (enemy.Health <= 0)
        {
            Debug.Log("Enemy umire");
        }
    }

 
}
    


