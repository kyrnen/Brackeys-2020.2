using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIndex : MonoBehaviour
{
    int MaxHealthPool = 0;
    int CurrentHealthPool = 0;
    // Start is called before the first frame update

    public void AddTower(int Max)
    {
        MaxHealthPool += Max;
        CurrentHealthPool += Max;
    }

    public void Damaged(int Amount)
    {
        CurrentHealthPool -= Amount;
    }

    public void Death(int Amount)
    {
        MaxHealthPool -= Amount;
    }
}
