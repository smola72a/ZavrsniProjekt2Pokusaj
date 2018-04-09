using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScaling : MonoBehaviour {

    public Vector2Int WeaponDamagePerLvl;
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
        ItemToUpgrade.StunChance += StunChancePerLvl;

        ItemToUpgrade.Protection += ProtectionPerLvl;
        ItemToUpgrade.AdditionalProtection += AdditionalProtectionPerLvl;
    }


   
}
