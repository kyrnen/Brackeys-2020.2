using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int maxIndex = 1;
    public void Play()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex != maxIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("You've reached the last level");
        }
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}