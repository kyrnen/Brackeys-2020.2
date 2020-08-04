using UnityEngine;
using UnityEngine.UI;

public class Enemy : PackageClass
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public int MaxHealth;
    public int currenthealth;

    [SerializeField] private bool moveForward = true;

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

    private void Start()
    {
        currenthealth = MaxHealth;
        Intro();
        SetMaxHealth(MaxHealth);
    }

    private void Intro()
    {
        Debug.Log(enemyName + ", " + currenthealth);
    }

    private void Update()
    {
        Move();
        CheckDirection();
        Damage();
    }

    void CheckDirection()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, wp.waypoints[wpIndex].position)) < 0.1f)
        {
            if (!moveForward)
            {
                if (wpIndex > 0)
                {
                    wpIndex--;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
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
        }
    }

    void Damage()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currenthealth -= damage;
        SetHealth(currenthealth);

        fill.color = gradient.Evaluate(slider.normalizedValue);
        SetHealth(currenthealth);
    }

    void FlipDirection()
    {
        moveForward = !moveForward;
    }
}