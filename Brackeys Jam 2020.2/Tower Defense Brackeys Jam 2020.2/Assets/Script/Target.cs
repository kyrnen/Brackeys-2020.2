using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;

public class Target : MonoBehaviour
{
    List<int> CheckedBy = new List<int>(); 
    bool IsBad = false;
    int AttackID = 0;
    float Health = 100;
    float[] DamageMultiplyer = new float[] { 0.8f, 1.2f, 0.5f };


    public void AddToList(int TowerID)
    {
        CheckedBy.Add(TowerID);
    }

    public int[] GetIDList()
    {
        return CheckedBy.ToArray();
    }
    public void Damage(int Amount, int Type)
    {
        Health -= Amount*DamageMultiplyer[Type];
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool GetFlagg()
    {
        return IsBad;
    }

    public void SetFlagg(bool State)
    {
        IsBad = State;
    }

    public int GetTypeID()
    {
        return AttackID;
    }
}
