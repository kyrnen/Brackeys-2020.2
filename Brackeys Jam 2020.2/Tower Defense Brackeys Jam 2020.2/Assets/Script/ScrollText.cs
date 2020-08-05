using UnityEngine;

public class ScrollText : MonoBehaviour
{
    public float speed;
    [SerializeField]
    float topBorder, bottomBorder;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.localPosition.y > topBorder) transform.localPosition = new Vector3(transform.localPosition.x, topBorder, 0f);
        if (transform.localPosition.y < bottomBorder) transform.localPosition = new Vector3(transform.localPosition.x, bottomBorder, 0f);
    }

    public void ChangeSpeed(float value) => speed = value;
}