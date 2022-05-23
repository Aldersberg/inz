using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public static healthBar hpBar;

    private void Awake()
    {
        
        if (healthBar.hpBar != null)
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
            return;
        }
        Debug.Log("awake");
        hpBar = this;
        DontDestroyOnLoad(gameObject);
    }
    public void updateHealthOnDamage(float hp, float maxHp)
    {
       //Debug.Log((player.hp / player.maxHp));
        transform.localScale = new Vector3((hp / maxHp), 1, 1);
    }
}
