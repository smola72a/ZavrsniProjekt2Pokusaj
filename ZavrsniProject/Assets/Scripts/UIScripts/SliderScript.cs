using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    HealthManager healthManager;
    string HealthManagerString;
    public Text HealthText;

    private void Start()
    {
       HealthText = GetComponent<Text>();
    }

    public void Update()
    {
     // HealthManagerString = healthManager.Health.ToString();
     // HealthText.text = HealthManagerString;
    }
   

}
