using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public class SOItem : ScriptableObject
{
    //TODO:EnemyType

    //Overall

    public ItemType itemType;
    public int MaxLevel;
    public int Level;
    public int UpgradeCost;

    //Weapon

    public string WeaponName;
    public EnemyType VsType = EnemyType.Bandits;
    public int Damage;
    public int AdditionalDamage;

    public float AttackSpeed;

    public bool ShouldStun;
    public float StunDuration;
    public float StunChance;

    //Armor

    public EnemyType ProtectionType = EnemyType.Bandits;
    public int Protection;
    public int AdditionalProtection;

    
	
		
	
}
