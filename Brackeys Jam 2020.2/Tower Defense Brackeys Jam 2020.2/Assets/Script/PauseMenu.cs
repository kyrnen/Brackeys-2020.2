 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUi;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
