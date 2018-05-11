using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public EnemyType ProtectionType = EnemyType.Bandits;

    public int MaxHealth;
    public int MaxArmor;
    public int MaxAdditionalArmor;

    public int Health = 100;
    public int Armor;

    public bool PlayerDied = false;
    public bool EnemyDied = false;


    private int _armorDamage;
    private int _damageLeft;

    private int _additionalArmor;
    private int _additionalArmorDamage;
    private int _additionalArmorDamageLeft;

   
    

    public void RestoreHealth()
    {
        Health = MaxHealth;
    }

    public void RestoreArmor()
    {
        Armor = MaxArmor;
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


        if (Armor > 0)
        {

            _damageLeft = 0;
            Armor -= amount;
            if (Armor < 0)
            {
                _damageLeft -= Armor;
                Armor = 0;
            }

            if (_damageLeft > 0)
            {
                Health -= _damageLeft;
            }

            if (Health <= 0)

                Debug.Log("Player umire");
            PlayerDied = true;
        }
    }


    public void EnemyLoseHealth(SOEnemy enemy, int amount)
    {
        enemy.Health -= amount;
        if (enemy.Health <= 0)
        {
            Debug.Log("Enemy umire");
            EnemyDied = true;
        }
    }

 
}
    


