using UnityEngine;

public class PackageClass : MonoBehaviour
{
    public bool isBad;
    public int power = 20;
    public float moveSpeed;

    [SerializeField] protected Waypoints wp;

    protected int wpIndex = 0;

    private void Awake()
    {
        wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    protected virtual void Move() 
    {
        transform.position = Vector3.MoveTowards(transform.position, wp.waypoints[wpIndex].position, moveSpeed * Time.deltaTime);

        ChangeDirection();
    }

    protected virtual void ChangeDirection()
    {
        Vector3 dir = wp.waypoints[wpIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}