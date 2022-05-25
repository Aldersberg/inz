using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : Collision
{
    public string sceneName;
    protected override void onCollision(Collider2D coll)
    {
        if(coll.name == gameManager.gmInstance.playerName)
        {

            gameManager.gmInstance.SaveState();
            SceneManager.LoadScene(sceneName);
        }
       
    }
}
