using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Enemy enemyClass;
    
    public int AmountOfmoney = 1000;
    public Text Text;
    void Start()
    {
        Text.text = AmountOfmoney.ToString("F2");
        enemyClass = GameObject.FindGameObjectWithTag("Package").GetComponent<Enemy>();
        Debug.Log(enemyClass.name);
    }

    void Update()
    {
        if (enemyClass.currenthealth <= 0)
        {
            AmountOfmoney = AmountOfmoney + 100;
            Debug.Log("Guy");
        }
        else
            return;
        Text.text = AmountOfmoney.ToString("F2");
    }
}
