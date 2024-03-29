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
    public GameObject speedPotionPrefab;
    public GameObject[] pfweaponDrops;
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
        
        dropItem();
        gameManager.gmInstance.showText("+"+gold+" gold" , 25 , Color.yellow, transform.position, Vector3.up * 25, 1.0f,true );
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        s.sprite = collected;
        boxCollider.enabled = false;
        gameManager.gmInstance.SaveState();

    }

    private void dropItem()
    {
        spawnWeapon();
        int item = Random.Range(1, 100);
        Debug.Log(item);
        if (item > 33)
        {
            spawnHpPot();
            spawnSpeedPot();
        }
        
        else
            spawnSpeedPot();
        //Debug.Log(item);
    }

    private void spawnHpPot()
    {
        Instantiate(hpPotionPrefab, new Vector3(transform.position.x, transform.position.y - 0.2f, 1), Quaternion.identity);
    }
    private void spawnSpeedPot()
    {
        Instantiate(speedPotionPrefab, new Vector3(transform.position.x, transform.position.y - 0.2f, 1), Quaternion.identity);
    }
    private void spawnWeapon()
    {
        GameObject go = Instantiate(pfweaponDrops[0]);
        go.GetComponent<weaponGO>().weapon = new weapon();
        go.GetComponent<weaponGO>().weapon.damage = Random.Range(1, 133);
        go.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, 1);
        //drop only a sprite and generate the rest in eq?
    }
}
//speedPotion speedPot = new speedPotion();
//speedPot.go = Instantiate(hpPotionPrefab);
//speedPot.setup();
////one square = 0.16f
//speedPot.go.transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, 1);