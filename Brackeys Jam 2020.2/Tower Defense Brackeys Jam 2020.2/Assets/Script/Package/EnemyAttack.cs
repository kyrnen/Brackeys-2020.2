using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth health;
    bool canAttack = true;
    [SerializeField]
    float attackDelay;
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
        if (Vector3.Distance(transform.position, health.transform.position) <= attackDistance && canAttack) StartCoroutine(DealDamage());
    }

    IEnumerator DealDamage()
    {
        Debug.Log("ATTACKING");
        canAttack = false;
        health.TakeDamage(damage);
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}