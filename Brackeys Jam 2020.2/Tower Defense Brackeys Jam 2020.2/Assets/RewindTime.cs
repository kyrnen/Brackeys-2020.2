using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    private bool isRewinding = false;
    public float timetorewind = 2f;
    List<PointInTime> PointInTime;
    void Start()
    {
        PointInTime = new List<PointInTime>();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Record()
    {
        if(PointInTime.Count > Mathf.Round(timetorewind / Time.fixedDeltaTime))
        {
            PointInTime.RemoveAt(PointInTime.Count - 1);
        }
        PointInTime.Insert(0, new PointInTime(transform.position,transform.rotation));
    } 
    void Rewind()
    {
        if (PointInTime.Count > 0)
        {
            PointInTime pointInTime = PointInTime[0];
            transform.position = pointInTime.Poition;
            transform.rotation = pointInTime.rotation;
            PointInTime.RemoveAt(0);
        }
        else
            StopRewind();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
    }
    void StartRewind()
    {
        isRewinding = true;
    }
    void StopRewind()
    {
        isRewinding = false;
    }
}
