using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class PathFinding : MonoBehaviour
{
    public Button ChooseRight;
    public Button ChooseLeft;

    public void Start()
    {
        
        Button RightButton = ChooseRight.GetComponent<Button>();
        Button LeftButton = ChooseLeft.GetComponent<Button>();

        RightButton.onClick.AddListener(ChooseRightPath);
        LeftButton.onClick.AddListener(ChooseLeftPath);

    }

    public void ChooseRightPath()
    {
        //Kretnje playera(environmenta), 
        Pool.pool.EnemyInBattle = GameManager.gm.RightEnemy;
        GameManager.gm.SwitchedPhase(GameplayPhase.Battle);
        
    }

    public void ChooseLeftPath()
    {
        Pool.pool.EnemyInBattle = GameManager.gm.LeftEnemy;
        GameManager.gm.SwitchedPhase(GameplayPhase.Battle);
    }
   
   

}
        
        
