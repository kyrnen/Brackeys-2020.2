using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    
    public int AmountOfmoney = 1000;
    public Text Text;
    void Start()
    {
        Text.text = AmountOfmoney.ToString("F2");
    }

    void Update()
    {

        Text.text = AmountOfmoney.ToString("F2");
    }
}
