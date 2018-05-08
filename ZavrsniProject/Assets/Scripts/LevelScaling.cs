using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScaling : MonoBehaviour {

    public int UpgradeCostPerLvl;

    public void UpgradeWeapon(SOItem ItemToUpgrade)
    {
        ItemToUpgrade.Damage += ItemToUpgrade.DamagePerLevel;
        ItemToUpgrade.AttackSpeed += ItemToUpgrade.AttackSpeedPerLevel;
    }


   
}
