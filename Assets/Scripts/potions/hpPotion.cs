using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPotion : Collision

{   [SerializeField]
    float hpRecovery = 3;

    public GameObject go;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sizes;
    int size;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //visibility on the floor
        spriteRenderer.sortingLayerName = "Floor";
        spriteRenderer.sortingOrder = 1;
        Debug.Log("in start hppot");
        size = Random.Range(0, 2);
        
        spriteRenderer.sprite = sizes[size];
        if (size == 0)
            hpRecovery = 5;
        else
            hpRecovery = 10;
    }
    public void setup()
    {
        go.SetActive(true);
        //sizes = go.GetComponent<Sprite[]>();
        //
        //
        //Debug.Log(sizes);
        //go.GetComponent<SpriteRenderer>().sprite = sizes[1];
        
    }
    protected override void onCollision(Collider2D coll)
    {
        if(coll.name == pName)
        {
            gameManager.gmInstance.player.hp += hpRecovery;
            gameManager.gmInstance.player.updateHp();
            gameManager.gmInstance.showText("+" + hpRecovery, 22, Color.green, transform.position, Vector3.up * 10, 0.3f, true);
            Destroy(gameObject);
        }
    }
}
