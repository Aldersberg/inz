using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class mapGen : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tiles;
    void Start()
    {
        
        for (float i = 0; i <= 1.6; i+=0.16f)
        {
            for (float j = 0; j <= 1.6; j += 0.16f)
            {
                //if ((i == 0)||(j==0)||(i==1.6)||j==(1.6))
                //{
                //    Vector3 k = new Vector3(i, j, 0);
                //    tilemap.SetTile(tilemap.WorldToCell(k), tiles[0]);
                //    Debug.Log(i+" "+j);
                //}
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
