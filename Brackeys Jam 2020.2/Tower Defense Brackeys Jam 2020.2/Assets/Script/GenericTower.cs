using System.Linq;
using UnityEngine;


public class GenericTower : MonoBehaviour
{
    public int TowerID = 0;
    public float Range = 10;
    public float ReloadTime = 500;
    public int Health = 500;
    float CurrentTime = 0;
    bool Charged = false;
    string TargetTag = "Package";
    Target CurrentTarget;
    public float InRangeRotation = 1;
    public float turnSpeed = 10;

    //Interact Data
    public int DamageAmount = -1;
    public int DamageType = 0;
    public int[] ScanTypes = new int[] { 1, 2 };

    void Start()
    {
    }

    void Update()
    {
        if (Charged && CurrentTarget == null)
        {
            GetPackages();
        }
        else if (Charged && CurrentTarget != null)
        {
            if (LockOnTarget() <= InRangeRotation)
            {
                Activate();
                Debug.Log("Activated");
            }
        }
        else if (CurrentTime <= ReloadTime)
        {
            CurrentTime++;
        }
        if (CurrentTime == ReloadTime && !Charged)
        {
            Charged = true;
            CurrentTime = 0;
        }
    }

    void Activate()
    {
        if (CurrentTarget != null)
        {
            Debug.Log(CurrentTarget);

            if (ScanTypes.Length != 0)
            {
                if (ScanTypes.Contains(CurrentTarget.GetTypeID()))
                {
                    CurrentTarget.SetFlagg(true);
                    CurrentTarget.AddToList(TowerID);
                    Debug.Log("Scanned Package");
                }
            }

            if (DamageAmount != -1 && CurrentTarget.GetFlagg() == true)
            {
                CurrentTarget.Damage(DamageAmount, DamageType);
                Debug.Log("Attacked Package");
            }

            CurrentTarget = null;
        }
    }

    float LockOnTarget()
    {
        //Lock onto target
        Vector3 dir = CurrentTarget.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        float RotationChange = lookRotation.eulerAngles.y - rotation.y;
        Debug.Log(RotationChange);
        return RotationChange;
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
