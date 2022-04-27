using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(1, 1), CursorMode.Auto);
    }
}
