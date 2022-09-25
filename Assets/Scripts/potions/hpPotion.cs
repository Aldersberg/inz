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
        spriteRenderer.sortingLayerName = "Misc.";
        spriteRenderer.sortingOrder = 1;
        Debug.Log("in start hppot");
        RandomizeSize();
    }
    void RandomizeSize()
    {
        size = Random.Range(0, 2);

        spriteRenderer.sprite = sizes[size];
        if (size == 0)
            hpRecovery = 15;
        else
            hpRecovery = 30;
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
        {   float hpRecovered = gameManager.gmInstance.player.maxHp * hpRecovery/100;
            gameManager.gmInstance.player.hp += hpRecovered;
            gameManager.gmInstance.player.updateHp();
            gameManager.gmInstance.showText("+" + hpRecovered, 22, Color.green, coll.transform.position, Vector3.up * 10, 0.3f, true);
            Destroy(gameObject);
        }
    }
}
