using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float health = 100f;

    public void TakeDamage(float amnt)
    {
        health -= amnt;
    }

    void Update()
    {
        if (health <= 0f) Respawn();
    }

    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}