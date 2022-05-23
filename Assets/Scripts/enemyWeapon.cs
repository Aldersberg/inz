using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeapon : Collision
{
    public float damage = 1;
    public float knockback = 1.0f;
    private string pName;
    protected override void Start()
    {
        base.Start();
        pName = gameManager.gmInstance.playerName;
    }

    protected override void onCollision(Collider2D coll)
    {
        if(coll.name == pName)
        {
            damage dmg = new damage();
            dmg.damageAmount = damage;
            dmg.knockback = knockback;
            dmg.origin = transform.position;
            coll.SendMessage("receiveDamage", dmg);
        }
    }
}
