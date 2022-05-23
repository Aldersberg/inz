using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Move
{
    
    protected override void Start()
    {
        base.Start();
        healthBar.hpBar.updateHealthOnDamage(hp, maxHp);
        
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        updateMovement(new Vector3(x, y, 0));
    }

    protected override void receiveDamage(damage dmg)
    {
        base.receiveDamage(dmg);

        healthBar.hpBar.updateHealthOnDamage(hp, maxHp);
    }
}
