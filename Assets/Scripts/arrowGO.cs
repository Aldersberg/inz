using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowGO : Collision
{ //test
    public float damage;
    float knockback;
    float arrowSpeed=0.01f;
    public Vector3 destination;
    Vector3 oldpos;
    Vector3 dir;
    float range = 1;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        dir = (transform.position - destination).normalized*arrowSpeed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        oldpos = transform.position;
        //Debug.Log(Vector2.MoveTowards(transform.position, destination, arrowSpeed));
        
        transform.position -= dir;
        //transform.position = Vector2.MoveTowards(transform.position, destination+dir, arrowSpeed);
        if(oldpos == transform.position||Vector3.Distance(transform.parent.position,transform.position)>range)
        {
            gameObject.GetComponent<arrowGO>().enabled = false;
            transform.parent.GetComponent<bowGO>().disabledArrowsAdd(gameObject);
        }
    }
   protected override void onCollision(Collider2D coll)
   {   
        //if colliding with another arrow do nothing
       if (coll.tag == "Arrow")
           return;
       //hit only damagable but not user
       if (coll.tag == "Damagable" )
       {
           damage dmg = new damage();
           dmg.damageAmount = damage;
           dmg.knockback = knockback;
           dmg.origin = transform.position;
           coll.SendMessage("receiveDamage", dmg);
       }
       Destroy(gameObject);
   }
}
