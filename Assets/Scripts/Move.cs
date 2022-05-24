using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Warrior
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveVector;
    protected RaycastHit2D collision;
    public float ySpeed = 0.5f;
    public float xSpeed = 0.5f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }
    

    protected virtual void updateMovement(Vector3 input)
    {
        moveVector = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        if (moveVector.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveVector.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //knockback
        moveVector += knockbackDir;
        knockbackDir = Vector3.Lerp(knockbackDir,Vector3.zero,knockbackRecoverySpeed);


        collision = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveVector.x, 0), Mathf.Abs(moveVector.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (collision.collider == null)
        {
            transform.Translate(moveVector.x  * Time.deltaTime, 0, 0);

        }

        collision = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveVector.y), Mathf.Abs(moveVector.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (collision.collider == null)
        {
            transform.Translate(0, moveVector.y  * Time.deltaTime, 0);

        }
    }
}
