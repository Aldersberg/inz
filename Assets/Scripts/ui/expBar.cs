using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expBar : MonoBehaviour
{
    public static expBar xpBar;
    private void Awake()
    {
        xpBar = this;

    }
    private void OnEnable()
    {
        
        int x = gameManager.gmInstance.player.level <= 0 ? 1 : gameManager.gmInstance.player.level;
        transform.localScale = new Vector3(((float)gameManager.gmInstance.player.experience / (x * 10)), 1, 1);
        //Debug.Log(((float)gameManager.gmInstance.player.experience / (x * 10)));
        Debug.Log(gameManager.gmInstance.player.experience+" "+ x);
        expValDisplay.xpValDisp.updateTxt(gameManager.gmInstance.player.experience, x * 10);
    }
    public void updateExpBar(int xp, int level)
    {
        int x = level<=0? 1 : level;   

        transform.localScale = new Vector3((xp / x*10), 1, 1);
        expValDisplay.xpValDisp.updateTxt(xp, x * 10);
    }
}
