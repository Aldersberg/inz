using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : Collision
{
    public Sprite collected;
    public Sprite[] weaponDrops;
    public Sprite[] weapontops;//top parts of weapons
    public Sprite[] potionDrops;
    public GameObject hpPotionPrefab;

    protected override void Start()
    {
        base.Start();
    }
    protected override void onCollision(Collider2D coll)    
    {   //check for player and input
        if (coll.name == pName && Input.GetKey(KeyCode.F))
        {
            //Debug.Log("chest collect");
            onChestInteraction();
        } 
    }
    void onChestInteraction()
    {
        int gold = Random.Range(1, 100);
        gameManager.gmInstance.gold += gold;
        Debug.Log("chest: "+transform.position.x);
        dropItem();
        //Debug.Log("onchest: "+this+":"+transform.name);
        gameManager.gmInstance.showText("+"+gold+" gold" , 25 , Color.yellow, transform.position, Vector3.up * 25, 1.0f,true );
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        s.sprite = collected;
        boxCollider.enabled = false;

    }

    private void dropItem()
    {

        hpPotion hpPot = new hpPotion();
        hpPot.go = Instantiate(hpPotionPrefab);
        //fix sizes
        //hpPot.sizes = hpPotionPrefab.sizes
        hpPot.setup();
        hpPot.go.transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, 1);
        //Debug.Log(transform.position.x);
        //int item = Random.Range(1, 100);
        //if (item > 33)
        //{
        //
        //}


    }
}
