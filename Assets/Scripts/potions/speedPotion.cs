using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedPotion : Collision
{
    [SerializeField]
    float speedUp = 3;
    //base speed=0.5f
    float duration=4;
    float startTime=0;
    bool active = false;
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

        size = Random.Range(0, 2);

        spriteRenderer.sprite = sizes[size];
        if (size == 0)
        {
            speedUp = 0.25f;
            duration = 4;
        }
        else
        {
            speedUp = 0.5f;
            duration = 3;
        }
        
    }
    protected override void Update()
    {
        base.Update();
        if (active)
        {
            if (Time.time - startTime > duration)
            {
                gameManager.gmInstance.player.xSpeed -= speedUp;
                gameManager.gmInstance.player.ySpeed -= speedUp;
                active = false;
                Destroy(gameObject);
            }
        }
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
        if (coll.name == pName)
        {
            startTime = Time.time;
            active = true;
            gameManager.gmInstance.player.xSpeed += speedUp;
            gameManager.gmInstance.player.ySpeed += speedUp;
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }
}
