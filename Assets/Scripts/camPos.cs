using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPos : MonoBehaviour
{
    public Transform camPosition;
    private void Start()
    {
        Camera.main.orthographicSize = 1.4f;
    }
    private void Update()
    {
        camZoom(Input.mouseScrollDelta.y);
    }
    void LateUpdate()
    {
        float dx = camPosition.position.x - transform.position.x;
        float dy = camPosition.position.y - transform.position.y;
        transform.position += new Vector3(dx,dy,0);
        
    }

    void camZoom(float mouseScroll)
    {
        if (mouseScroll > 0)
        {
            Camera.main.orthographicSize -= 0.1f;
            if (Camera.main.orthographicSize < 0.3)
                Camera.main.orthographicSize = 0.3f;
        }
        if (mouseScroll < 0)
        {
            Camera.main.orthographicSize += 0.1f;
            if (Camera.main.orthographicSize > 1.4)
                Camera.main.orthographicSize = 1.4f;
        }
    }
}
