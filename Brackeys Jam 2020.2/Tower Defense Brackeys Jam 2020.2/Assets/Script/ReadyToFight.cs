using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyToFight : MonoBehaviour
{
    public bool ReadyToFightButton;
    public Button texttodisable;

    void Update()
    {
        if (ReadyToFightButton == true)
        {
            GetComponent<WaveManager>().enabled = true;
        }
    }
    public void OnPressReadyToFightButton()
    {
        ReadyToFightButton = true;
        texttodisable.enabled = false;
    }
}
