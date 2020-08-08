using System.Collections;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;
    public int currentHealth;
    [SerializeField] public GameManager gm;
    [SerializeField] public MoneyManager mm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        mm = gm.gameObject.GetComponent<MoneyManager>();
        currentHealth = MaxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Package")
        {
            GameObject package = collision.gameObject;
            Enemy e = package.GetComponent<Enemy>();
            
            
            if (e.CheckScannedAndNotBad())
            {
                StartCoroutine(AddPoints(e.power));
                Destroy(package);
            }
            else
            {
                DamageWall(e.power);
                Destroy(package);

                if (currentHealth <= 0)
                {
                    Destroy(gameObject);
                    gm.GameOver();
                }
            }
        }
    }

    void DamageWall(int dmg)
    {
        currentHealth -= dmg;
    }

    IEnumerator AddPoints(int points)
    {
        mm.PackageDelivered(points);
        yield return null;
    }
}
