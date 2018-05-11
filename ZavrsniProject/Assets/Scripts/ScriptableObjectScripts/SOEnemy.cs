using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class SOEnemy : ScriptableObject
{
    public string Name;
    public Sprite EnemySprite;

    public EnemyType enemyType = EnemyType.Bandits;

    public int Health;
    public int HealthPerLevel;

    public Vector2Int Damage;
    public Vector2Int DamagePerLevel;

    public float AttackSpeed;
    public float AttackSpeedPerLevel;

    public bool ShouldStun;
    public int StunChance;
    public float StunDuration;

    public int Level;
    

   
   
    






}
