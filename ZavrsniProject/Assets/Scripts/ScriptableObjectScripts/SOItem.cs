using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public class SOItem : ScriptableObject
{


    //Overall

   

    public string Name;
    public ItemType itemType;
    public int MaxLevel;
    public int Level;
    public int UpgradeCost;
    public Sprite Icon;

    //dali cemo raditi default armor i weapon
    [Space(30)]
    
   

    //Weapon


    public EnemyType VsType = EnemyType.Bandits;
    public int Damage;
    public int AdditionalDamage;

    public float AttackSpeed;

    public bool ShouldStun;
    public float StunDuration;
    public float StunChance;

    [Space(30)]

  
    //Armor

    public EnemyType ProtectionType = EnemyType.Bandits;
    public int Protection;
    public int AdditionalProtection;

    
}
