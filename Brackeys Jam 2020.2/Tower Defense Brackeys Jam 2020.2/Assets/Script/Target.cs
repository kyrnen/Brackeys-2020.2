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
    int Health = 100;


    public void AddToList(int TowerID)
    {
        CheckedBy.Add(TowerID);
    }

    public int[] GetIDList()
    {
        return CheckedBy.ToArray();
    }
    public void Damage(int Amount)
    {
        Health -= Amount;
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

    public int GetID()
    {
        return AttackID;
    }
}
