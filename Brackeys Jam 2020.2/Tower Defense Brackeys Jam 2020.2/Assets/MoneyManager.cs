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
    void Awake()
    {
        Text.text = AmountOfmoney.ToString("F2");
    }

    void Update()
    {
        Text.text = AmountOfmoney.ToString("F2");
    }

    public void EnenyDied()
    {
        AmountOfmoney += 100;
    }
}
