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
        spriteRenderer.sortingLayerName = "Floor";
        spriteRenderer.sortingOrder = 1;
        
        size = Random.Range(0, 2);
        Debug.Log(size);
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
        //Debug.Log(go);
        //Debug.Log(sizes);
        //go.GetComponent<SpriteRenderer>().sprite = sizes[1];
        
    }
    protected override void onCollision(Collider2D coll)
    {
        if(coll.name == pName)
        {
            gameManager.gmInstance.player.hp += hpRecovery;
            gameManager.gmInstance.player.updateHp();
            Destroy(gameObject);
        }
    }
}
