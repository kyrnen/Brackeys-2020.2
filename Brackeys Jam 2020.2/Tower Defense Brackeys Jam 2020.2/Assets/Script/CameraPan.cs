using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    CharacterController controller;

    void Start() => controller = GetComponent<CharacterController>();

    void Update() => Move();

    void Move()
    {
        controller.Move(new Vector3(Input.GetAxisRaw("Vertical") * -1f, 0f, Input.GetAxisRaw("Horizontal")) * moveSpeed * Time.deltaTime);
    }
}