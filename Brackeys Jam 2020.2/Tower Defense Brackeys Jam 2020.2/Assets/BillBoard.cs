using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam;
    public void Start()
    {
        cam = Camera.main.transform;
    }
    void FixedUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
