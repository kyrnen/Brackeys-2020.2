using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUi;
    public GameObject GameUI;

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

    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void Pause()
    {
        GameUI.SetActive(false);
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void loadmenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("1");
        Time.timeScale = 1;
    }

    public void quittingame()
    {
        Debug.Log("quittingame");
        Application.Quit();
    }
}
