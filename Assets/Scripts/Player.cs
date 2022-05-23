using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Move
{
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        updateMovement(new Vector3(x, y, 0));
    }

}
