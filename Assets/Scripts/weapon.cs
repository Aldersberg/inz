using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class weapon : Collision
{
    public float damage = 1.0f;
    public float knockback = 1.0f;

    public GameObject go;
    private SpriteRenderer spriteRenderer;

    private float cooldown = 0.5f;
    private float lastAttack;
    string parentName="";
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (transform.parent != null)
        {
            //Debug.Log(this.name + ":" + transform.parent.name);
            parentName = transform.parent.name;
        }
        if (transform.parent == null)
        {
            spriteRenderer.sortingLayerName = "Weapon";
            spriteRenderer.sortingOrder = 1;
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Weapon";
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            animator.enabled = false;
        }
        
    }
    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0) && parentName == pName)
        {
            if(Time.time - lastAttack > cooldown)
            {
                lastAttack = Time.time;
                swing();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && parentName == pName)
        {
            if (Time.time - lastAttack > cooldown)
            {
                lastAttack = Time.time;
                throwWeapon();
            }
        }
    }

    protected override void onCollision(Collider2D coll)
    {   //if weapon is not the one used by player currently
        if (parentName == "")
        {
           if(coll.name == pName)
           {
                onPickup();
                return;
            } 
        }
        //hit only damagable but not user
        if(coll.tag == "Damagable" && coll.name!= parentName)
        {
            damage dmg = new damage();
            dmg.damageAmount = damage;
            dmg.knockback = knockback;
            dmg.origin = transform.position;
            coll.SendMessage("receiveDamage", dmg);
        }
    }
    private void onPickup()
    {   //set player weapon sprite to this one
        //GameObject currentWeapon = GameObject.Find(pName).transform.GetChild(0).gameObject;
        //currentWeapon.GetComponent<SpriteRenderer>().sprite = this.spriteRenderer.sprite;
        //GameObject currentWeapon1 = currentWeapon.transform.GetChild(0).gameObject;
        //currentWeapon1.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        //
        ////transfer weapon stats
        //currentWeapon.GetComponent<weapon>().damage = this.damage + currentWeapon.GetComponentInParent<Player>().strength;
        //currentWeapon.GetComponent<weapon>().knockback = this.knockback;
        //currentWeapon.GetComponent<weapon>().boxCollider = this.boxCollider;
        
        gameManager.gmInstance.inventory.Add(gameObject);
        gameManager.gmInstance.SaveState();

        string[] saveData = PlayerPrefs.GetString("saveState").Split('|');
        gameManager.gmInstance.inventory.Clear();
        gameManager.gmInstance.loadInventory(saveData);

        //playerInventory tmp = inventoryRef.GetComponent<playerInventory>();
        //tmp.refreshInventoryObjects();
        Destroy(gameObject);
        
    }
    private void swing()
    {
        animator.SetTrigger("Swing");
    }
    private void throwWeapon()
    {
        animator.SetTrigger("Throw");
    }
}
