using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    private Waypoints wp;

    private int wpIndex = 0;

    private void Start()
    {
        wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wp.waypoints[wpIndex].position, speed * Time.deltaTime);

        Vector3 dir = wp.waypoints[wpIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);


        if (Vector3.Distance(transform.position, wp.waypoints[wpIndex].position) < 0.1f)
        {
            if(wpIndex < wp.waypoints.Length - 1)
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
