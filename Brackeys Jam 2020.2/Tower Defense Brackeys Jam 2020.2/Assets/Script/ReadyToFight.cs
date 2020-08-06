using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyToFight : MonoBehaviour
{
    public bool ReadyToFightButton;
    public Button texttodisable;
    private void Start()
    {
        Button btn = texttodisable.GetComponent<Button>();
    }

    void Update()
    {
        if (ReadyToFightButton == true)
        {
            GetComponent<WaveManager>().enabled = true;
        }
        texttodisable.onClick.AddListener(OnPressReadyToFightButton);
    }
    
    public void OnPressReadyToFightButton()
    {
        ReadyToFightButton = true;
        texttodisable.enabled = false;
    }
}
