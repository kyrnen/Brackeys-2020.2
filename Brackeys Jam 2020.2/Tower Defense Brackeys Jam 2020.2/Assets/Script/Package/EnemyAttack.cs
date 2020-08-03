using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth health;
    [SerializeField]
    float attackDistance;
    [SerializeField]
    float damage;

    void Start()
    {
        health = PlayerHealth.instance;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, health.transform.position) <= attackDistance) DealDamage();
    }

    void DealDamage()
    {
        health.TakeDamage(damage);
        Destroy(gameObject);
    }
}