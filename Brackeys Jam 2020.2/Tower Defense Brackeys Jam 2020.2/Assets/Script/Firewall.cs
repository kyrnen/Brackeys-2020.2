using UnityEngine;

public class Firewall : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;
    public int currentHealth;



    private void Start()
    {
        currentHealth = MaxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Package")
        {
           
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            
            if (e.isBad)
            {
                DamageWall(e.power);
                Destroy(collision.gameObject);

                if(currentHealth <= 0)
                {
                    Destroy(gameObject);
                    Debug.LogError("Init Game Over");
                }
            }
            else
            {
                AddPoints(e.power);
            }
        }
    }

    void DamageWall(int dmg)
    {
        currentHealth -= dmg;
    }

    void AddPoints(int points)
    {
        Debug.Log("Add points to player score");
    }
}
