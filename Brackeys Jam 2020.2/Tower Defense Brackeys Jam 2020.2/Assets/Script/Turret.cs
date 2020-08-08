using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    
    [Header("General")]
    public float range = 5f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPref;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Reversal Beam")]
    public bool useBeam = false;
    public LineRenderer lineRender;
    public float delay = 5f;
    public float delayMax = 5f;

    [Header("Use Scan Beam")]
    public GameObject scanBulletPref;
    public bool useScanner = false;

    
    [Header ("Setup Fields")]
    public string enemyTag = "Package";
    public Transform rotatingObject;
    public float turnSpeed = 10f;
   
    
    public Transform firePoint;
    

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(useBeam)
            {
                if(lineRender.enabled)
                    lineRender.enabled = false;
            }
            return;
        }

        Enemy targetPackage = target.gameObject.GetComponent<Enemy>();

        if (!targetPackage.GetScanStatus() && useScanner)
        {
            
            LockOnTarget();

            Scan();
            fireCountdown = 1.3f;
            
            fireCountdown -= Time.deltaTime;
        }
        else {
            LockOnTarget();

            if (useBeam)
            { 
                if (delay == delayMax)
                {
                    Beam();
                    target.gameObject.GetComponent<Enemy>().FlipDirection();
                    delay -= Time.deltaTime;
                }
                else if (delay > delayMax / 2)
                {
                    Beam();
                    delay -= Time.deltaTime;
                }
                else if (delay < delayMax /2)
                {
                    lineRender.enabled = false;
                    delay -= Time.deltaTime;
                }
                else if (delay <= 0f)
                {
                    delay = delayMax;
                }
                
            } 
            else
            {
                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        //Lock onto target        
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatingObject.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatingObject.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Scan()
    {
        Enemy e = target.gameObject.GetComponent<Enemy>();

        GameObject bulletGO = (GameObject)Instantiate(scanBulletPref, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        bullet.Seek(target);

        e.SetScanned();
        //  change asset of enemy appropriately
    }

    void Beam()
    {
        if (!lineRender.enabled)
            lineRender.enabled = true;

        lineRender.SetPosition(0, firePoint.position);
        lineRender.SetPosition(1, target.position);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
