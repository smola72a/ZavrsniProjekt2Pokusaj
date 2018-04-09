using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class SOEnemy : ScriptableObject
{
    public EnemyType enemyType = EnemyType.Bandits;

    public int StartingHealth;
    public int Health;
    public int HealthPerLevel;

    public int Damage;
    public int DamagePerLevel;

    public float AttackSpeed;
    public float AttackSpeedPerLevel;

    public bool ShouldStun;
    public float StunChance;
    public float StunDuration;

    public int MaxLevel;
    public int Level;

    






}
