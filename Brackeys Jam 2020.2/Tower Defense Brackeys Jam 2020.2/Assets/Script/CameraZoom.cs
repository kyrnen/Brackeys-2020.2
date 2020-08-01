using UnityEngine;
using static UnityEngine.Mathf;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    float zoomSpeed;
    [SerializeField]
    float minZoom;
    [SerializeField]
    float maxZoom;
    new Camera camera;

    void Start() => camera = GetComponent<Camera>();

    void Update() => Zoom();

    void Zoom()
    {
        camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        camera.fieldOfView = Clamp(camera.fieldOfView, minZoom, maxZoom);
    }
}
