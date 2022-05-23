using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public float hp = 10;
    public float maxHp = 10;
    public float knockbackRecoverySpeed = 0.1f;
    protected float immuneTime = 0.5f;
    protected float lastImmune;
    protected Vector3 knockbackDir;

    protected virtual void receiveDamage(damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hp -= dmg.damageAmount;
            knockbackDir = (transform.position - dmg.origin).normalized * dmg.knockback;

            gameManager.gmInstance.showText("-"+dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 10, 0.5f, true);

            if (hp <= 0)
            {
                hp = 0;
                death();
            }
        }
    }

    protected virtual void death()
    {
        //Destroy(this);
    }

}

