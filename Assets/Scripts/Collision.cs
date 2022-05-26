using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public ContactFilter2D filter;
    protected BoxCollider2D boxCollider;
    private Collider2D[] collisions = new Collider2D[40];
    protected string pName;
    // Start is called before the first frame update
    //Console.WriteLine("Area of Circle   = {0:F2}", c.Area());
    //Console.WriteLine($"x = {dpoint.x}, y = {dpoint.y}");
    protected virtual void Start()
    {
        Debug.Log(this.name);
        boxCollider = GetComponent<BoxCollider2D>();
        pName = gameManager.gmInstance.playerName;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (boxCollider==null)
            boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.OverlapCollider(filter, collisions);
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] == null)
                continue;
            
            onCollision(collisions[i]);
            
            collisions[i] = null;
        }
    }
    protected virtual void onCollision(Collider2D coll)
    {
        //Debug.Log(coll.name);
    }
}
