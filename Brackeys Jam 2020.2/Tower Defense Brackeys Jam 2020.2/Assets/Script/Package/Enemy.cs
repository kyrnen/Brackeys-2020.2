using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PackageClass
{
    [SerializeField] private string enemyName;

    private float hp;

    [SerializeField] private float maxHP;

    private void Start()
    {
        hp = maxHP;
        Intro();
    }
    private void Intro()
    {
        Debug.Log(enemyName + ", " + hp);
    }

    private void Update()
    {
        Move();

        if (Vector3.Distance(transform.position, wp.waypoints[wpIndex].position) < 0.1f)
        {
            if (wpIndex < wp.waypoints.Length - 1)
            {
                wpIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
