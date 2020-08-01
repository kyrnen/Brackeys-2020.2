using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;

public class GenericTower : MonoBehaviour
{
    int TowerID = 0;
    float Range = 10;
    float ReloadTime = 1000;
    float CurrentTime = 0;
    bool Charged = false;
    string TargetTag = "Package";
    Target CurrentTarget;

    //Interact Data
    int DamageAmmount = 0;
    int DamageType = 0;
    int ScannType = 0;
    float Probability = 0.7f;

    void Start()
    {
    }

    void Update()
    {
        if (Charged)
        {
            Activate();
        }
        else if(CurrentTime <= ReloadTime)
        {
            CurrentTime++;
        }
        if(CurrentTime == ReloadTime && !Charged)
        {
            Charged = true;
            CurrentTime = 0;
        }
        Debug.Log(CurrentTime);
    }

    void Activate()
    {
        GetPackages();
        if(CurrentTarget != null)
        {
            Debug.Log(CurrentTarget);
            CurrentTarget.AddToList(TowerID);
            CurrentTarget = null;
        }
    }

    void GetPackages()
    {
        GameObject[] AllPackages = GameObject.FindGameObjectsWithTag(TargetTag);
        foreach (GameObject P in AllPackages)
        {
            if (Vector3.Distance(P.transform.position, this.transform.position) < Range)
            {
                if (P.GetComponent<Target>().GetIDList().Contains(TowerID) == false)
                {
                    CurrentTarget = P.GetComponent<Target>();
                    break;
                }
            }
        }
    }
}
