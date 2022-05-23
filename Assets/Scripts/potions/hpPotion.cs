using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPotion : Collision
{
    protected override void onCollision(Collider2D coll)
    {
        if(coll.name == pName)
        {
            gameManager.gmInstance.player.hp += 3;
            gameManager.gmInstance.player.updateHp();
            Destroy(gameObject);
        }
    }
}
