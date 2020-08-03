using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField]
    float health = 100f;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Gradient healthColor;

    [SerializeField]
    Image fill;

    void Start()
    {
        instance = this;
        SetHealthBar();
    }

    public void TakeDamage(float amnt)
    {
        health -= amnt;
        SetHealthBar();
    }

    void Update()
    {
        if (health <= 0f) Respawn();
    }

    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetHealthBar()
    {
        healthBar.value = health;
        fill.color = healthColor.Evaluate(healthBar.normalizedValue);
    }
}