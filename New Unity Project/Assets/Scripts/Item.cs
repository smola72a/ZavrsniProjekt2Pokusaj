using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name = "New Item";
    public Sprite Icon;
    [Range(1,1000)]
    public int Value = 0;

    public void Use()
    {
        Debug.Log("Item Used" + name);
    }
}


	
