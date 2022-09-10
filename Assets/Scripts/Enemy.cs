using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Move
{
    public int xpGrantedOnKill=1;

    public float visionDistance = 0.32f;

    private bool chasing;
    private bool collidingWithPlayer;

    private Transform playerTransform;

    private BoxCollider2D hitbox;
    private Collider2D[] collisions = new Collider2D[10];
    private ContactFilter2D filter;
    private string pName;

    protected void Awake()
    {
        
    }
    protected override void Start()
    {
        playerTransform = gameManager.gmInstance.player.transform;
        hitbox = GetComponent<BoxCollider2D>();
        xSpeed = 0.3f;
        ySpeed = xSpeed;
        pName = gameManager.gmInstance.playerName;
        RandomizeEnemyToughness();
        base.Start();
        
    }

    private void Update()
    {
        //is playrer in visionDistance
        if (Vector3.Distance(playerTransform.position, transform.position) <= visionDistance)
        {
            chasing = true;
        }
        else
            chasing = false;

        if (chasing && !collidingWithPlayer)
        {   //move towards player but stop upon collision
            //Debug.Log("chasing");
            updateMovement((playerTransform.position-transform.position).normalized);
        }

        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, collisions);
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] == null)
                continue;
            //Debug.Log(collisions[i].name);
            if (collisions[i].name == pName)
                collidingWithPlayer = true;

            collisions[i] = null;
        }
    }

    protected override void death()
    {
        Destroy(gameObject);
        gameManager.gmInstance.player.addExperience(xpGrantedOnKill);
        //gameManager.gmInstance.exp += xpGrantedOnKill;
        gameManager.gmInstance.showText("+"+xpGrantedOnKill+" xp", 23, Color.blue, transform.position, Vector3.up * 5, 0.5f, true);
    }
    private void RandomizeEnemyToughness()
    {
        int rarity = Random.Range(1, 4);
        xpGrantedOnKill*=rarity;

        hp*=rarity;
        maxHp=hp;

        GetComponent<enemyWeapon>().damage *= rarity;
    }
}
