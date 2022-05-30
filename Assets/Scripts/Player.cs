using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Move
{
    public int strength;
    public int vitalty;
    public int speed;
    protected override void Start()
    {
        base.Start();
        updateHp();
        updateSpeed();
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
        updateHp();


    }
    public void updateStr()
    {

    }
    public void updateVit()
    {
        maxHp += vitalty;
    }
    public void updateSpeed()
    {
        ySpeed += speed*0.1f;
    }
    public void updateHp()
    {
        if (hp < 0)
            hp = 0;
        if (hp > maxHp)
            hp = maxHp;
        healthBar.hpBar.updateHealthOnDamage(hp, maxHp);
    }
}
