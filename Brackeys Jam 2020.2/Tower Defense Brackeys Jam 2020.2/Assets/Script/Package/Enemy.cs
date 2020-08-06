using UnityEngine;
using UnityEngine.UI;

public class Enemy : PackageClass
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public int MaxHealth;
    public int currenthealth;

    public Text Moneycount;

    public int MoneyForKill = 1;

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

    public virtual void Damage()
    {
        TakeDamage(20);

        if (currenthealth <= 0)
        {
            Destroy(gameObject);
            Moneycount.text = Moneycount.text + MoneyForKill.ToString();
        }
    }

    protected override void ChangeDirection()
    {
        Vector3 dir;

        if (!moveForward && wpIndex != wp.waypoints.Length - 1)
        {
            dir = wp.waypoints[wpIndex + 1].position - transform.position;
        }
        else
        {
            dir = wp.waypoints[wpIndex].position - transform.position;
        }

        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

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