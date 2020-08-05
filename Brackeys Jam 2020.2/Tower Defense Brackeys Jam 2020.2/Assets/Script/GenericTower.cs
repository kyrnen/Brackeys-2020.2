using System.Linq;
using UnityEngine;


public class GenericTower : MonoBehaviour
{
    public int TowerID = 0;
    public float Range = 10;
    public float ReloadTime = 500;
    float CurrentTime = 0;
    bool Charged = false;
    string TargetTag = "Package";
    Target CurrentTarget;

    //Interact Data
    public int DamageAmount = -1;
    public int DamageType = 0;
    public int[] ScanTypes = new int[] { 1, 2 };

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

            if(ScanTypes.Length != 0)
            {
                if(ScanTypes.Contains(CurrentTarget.GetTypeID()))
                {
                    CurrentTarget.SetFlagg(true);
                    CurrentTarget.AddToList(TowerID);
                    Debug.Log("Scanned Package");
                }
            }

            if(DamageAmount != -1 && CurrentTarget.GetFlagg() == true)
            {
                CurrentTarget.Damage(DamageAmount,DamageType);
                Debug.Log("Attacked Package");
            }

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
