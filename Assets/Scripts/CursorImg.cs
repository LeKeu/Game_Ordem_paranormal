using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorImg : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
