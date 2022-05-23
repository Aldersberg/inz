using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : Collision
{
    public float damage = 1.0f;
    public float knockback = 1.0f;

    public int weaponLvl = 0;
    private SpriteRenderer spriteRenderer;

    private float cooldown = 0.5f;
    private float lastAttack;
    string parentName;
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentName = transform.parent.name;
        animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0))
        {
            if(Time.time - lastAttack > cooldown)
            {
                lastAttack = Time.time;
                swing();
            }
        }
    }

    protected override void onCollision(Collider2D coll)
    {   //hit only damagable but not user
        if(coll.tag == "Damagable" && coll.name!= parentName)
        {
            damage dmg = new damage();
            dmg.damageAmount = damage;
            dmg.knockback = knockback;
            dmg.origin = transform.position;
            coll.SendMessage("receiveDamage", dmg);
        }
    }

    private void swing()
    {
        animator.SetTrigger("Swing");
    }
}
