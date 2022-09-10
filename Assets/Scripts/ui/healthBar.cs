using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public static healthBar hpBar;
    private void Awake()
    {
        hpBar = this;
        
    }
    
    public void updateHealthOnDamage(float hp, float maxHp)
    {
       //Debug.Log((player.hp / player.maxHp));

        transform.localScale = new Vector3((hp / maxHp), 1, 1);
        healthBarDisp.hpBarDisp.updateTxt(hp, maxHp);
    }
}
