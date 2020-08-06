using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam;
    void FixedUpdate()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        transform.LookAt(transform.position + cam.forward);
    }
}
