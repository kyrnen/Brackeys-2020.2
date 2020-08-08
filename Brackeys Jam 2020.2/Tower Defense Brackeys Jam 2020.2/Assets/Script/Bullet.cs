using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public bool doesDamage;

    public void Seek(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distThisFrame, Space.World);


    }

    void HitTarget()
    {
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 2f);

        if (doesDamage)
        {
            target.gameObject.GetComponent<Enemy>().Damage();
        }
        Destroy(gameObject);
    }

}
