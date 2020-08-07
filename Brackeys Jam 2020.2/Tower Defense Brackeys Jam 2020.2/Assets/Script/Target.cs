using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    List<int> CheckedBy = new List<int>();
    public bool IsBad = false;
    int AttackID = 1;
    float Health = 100;
    private MoneyManager MM;
    float[] DamageMultiplyer = new float[] { 0.8f, 1.2f, 0.5f };

    private void Start()
    {
        MM = GameObject.Find("SystemFirewall").GetComponent<MoneyManager>();
    }

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
        Health -= Amount * DamageMultiplyer[Type];
        if (Health <= 0)
        {
            Debug.Log("Enemy Died");
            MM.EnenyDied();
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
        if (IsBad)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public int GetTypeID()
    {
        return AttackID;
    }
}