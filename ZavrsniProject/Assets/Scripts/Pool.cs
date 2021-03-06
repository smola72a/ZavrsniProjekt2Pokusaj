﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool pool;

    public SOItem WeaponOnPlayer;
    public SOItem ArmorOnPlayer;
    public SOEnemy EnemyInBattle;
    public int EnemyLevel;
    public int ItemLevel;
    public int ItemMinLevel;



    public List<SOItem> AllWeaponsPrefabs = new List<SOItem>();
    public List<SOItem> AllArmorsPrefabs = new List<SOItem>();
    public List<SOItem> AllItemsPrefabs = new List<SOItem>();
    public List<SOEnemy> AllEnemiesPrefabs = new List<SOEnemy>();
    public List<SOItem> ItemsInInventory = new List<SOItem>();

    public void Awake()
    {
        pool = this;
    }
}