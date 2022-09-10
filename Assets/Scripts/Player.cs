using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Move
{
    public int strength;
    public int vitalty;
    public int speed;
    public int experience=0;
    public int level=1;
    public int skillThrow;
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
        GetComponentInChildren<weapon>().damage += strength;
    }
    public void updateVit()
    {
        maxHp += vitalty;
        updateHp();
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
    //public void initExp()
    //{
    //    expBar.xpBar.updateExpBar(experience, level);
    //}
    public void addExperience(int expToAdd)
    {
        experience += expToAdd;
        checkLvlUp();
        //expBar.xpBar.updateExpBar(experience,level);
    }
    private void checkLvlUp()
    {
        if(level<=0)
            level=1;

        if (experience >= (level * 10))
        {
            experience -= (level * 10);
            level+=1;
            Debug.Log("checked lvlup");
            checkLvlUp();
        }
    }
}
