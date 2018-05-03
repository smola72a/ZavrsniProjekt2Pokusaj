using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDamage : MonoBehaviour
{
    public Text PlayerDamage;
    public Text PlayerAdditionalDamage;

    public Text EnemyDamage;
    public Text EnemyAdditionalDamage;

    public float ShowDamageTime = 0.2f;

    public IEnumerator ShowPlayerDamage(int playerDamage)
    {
        PlayerDamage.text = playerDamage.ToString();
        yield return new WaitForSeconds(ShowDamageTime);
        
    }
	
}
