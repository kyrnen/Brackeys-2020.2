using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public static TurretManager instance;
    [SerializeField]
    GameObject[] turrets;
    public GameObject currentTurret { get; private set; }

    void Awake()
    {
        instance = this;
        currentTurret = turrets[0];
    }

    public void SetTurret(int turretIndex)
    {
        currentTurret = turrets[turretIndex];
    }
}