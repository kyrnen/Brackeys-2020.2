using UnityEngine;
using UnityEngine.UI;
public class Enemy : PackageClass
{
    public Slider slider;

    public Gradient gradient;

    public Image fill;

    public int MaxHealth = 100;

    public int currenthealth;
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    [SerializeField] private string enemyName;

    private float hp;

    [SerializeField] private float maxHP;

    private void Start()
    {
        hp = maxHP;
        Intro();
        SetMaxHealth(MaxHealth);
        currenthealth = MaxHealth;
    }
    private void Intro()
    {
        Debug.Log(enemyName + ", " + hp);
    }

    private void Update()
    {
        Move();

        if (Vector3.Distance(transform.position, wp.waypoints[wpIndex].position) < 0.1f)
        {
            if (wpIndex < wp.waypoints.Length - 1)
            {
                wpIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }


    void TakeDamage(int damage)
    {
        currenthealth -= damage;
        SetHealth(currenthealth);

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
