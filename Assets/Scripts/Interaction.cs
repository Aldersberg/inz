using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : Collision
{
    public Sprite collected;
    // Start is called before the first frame update
    protected override void onCollision(Collider2D coll)
    {
        if (coll.name == "wizard_0")
        {
            Debug.Log("geld");

            SpriteRenderer s = GetComponent<SpriteRenderer>();
            s.sprite =collected ;
            coll.enabled = false;
        }
    }
}
