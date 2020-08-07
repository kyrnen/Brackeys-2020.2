using UnityEngine;

public class ResizeTiles : MonoBehaviour
{
    [SerializeField]
    Transform resizeableTiles;
    bool canMove;
    [SerializeField]
    Transform rightBarrier, leftBarrier;
    [SerializeField]
    Texture2D dragCursor, defaultCursor;

    void OnMouseDrag()
    {
        canMove = true;
        Cursor.SetCursor(dragCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        canMove = false;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }


    void Update()
    {
        if (canMove && Input.GetMouseButton(0)) transform.Translate(new Vector3(0f, 0f, Input.GetAxis("Mouse X")));
        if (Input.GetMouseButtonUp(0)) Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, leftBarrier.position.z, rightBarrier.position.z));
        resizeableTiles.position = new Vector3(resizeableTiles.position.x, resizeableTiles.position.y, transform.position.z);
    }
}