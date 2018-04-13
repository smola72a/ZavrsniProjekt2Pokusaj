using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScaling : MonoBehaviour {

    public int WeaponDamagePerLvl;
    public float WeaponSpeedPerLvl;
    public float StunDurationPerLvl;
    public float StunChancePerLvl;

    public int ProtectionPerLvl;
    public int AdditionalProtectionPerLvl;

    public int UpgradeCostPerLvl;


    public void UpgradeItem(SOItem ItemToUpgrade)
    {
        ItemToUpgrade.Damage += WeaponDamagePerLvl;
        ItemToUpgrade.AttackSpeed += WeaponSpeedPerLvl;
        ItemToUpgrade.StunDuration += StunDurationPerLvl;
        ItemToUpgrade.StunChance = Random.Range(0, StunChancePerLvl); //tebi pustam ovaj %....

        ItemToUpgrade.Protection += ProtectionPerLvl;
        ItemToUpgrade.AdditionalProtection += AdditionalProtectionPerLvl;
    }


   
}
