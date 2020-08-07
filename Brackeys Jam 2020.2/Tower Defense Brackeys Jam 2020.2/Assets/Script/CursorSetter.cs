using UnityEngine;

public class CursorSetter : MonoBehaviour
{
    [SerializeField]
    Texture2D defaultCursor;

    void Awake()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}