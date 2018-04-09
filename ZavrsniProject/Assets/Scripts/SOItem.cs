using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public class SOItem : ScriptableObject
{
    //Overall

    public int MaxLevel;
    public int Level;
    public int UpgradeCost;

    //Weapon

    public string WeaponName;
    public Vector2Int Damage;

    public float AttackSpeed;

    public bool ShouldStun;
    public float StunDuration;
    public float StunChance;

    //Armor

    public DamageType ProtectionType = DamageType.DmgBandits;
    public int Protection;
    public int AdditionalProtection;

    
	
		
	
}
