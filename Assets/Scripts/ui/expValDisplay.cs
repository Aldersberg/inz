using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class expValDisplay : MonoBehaviour
{
    public static expValDisplay xpValDisp;
    private TMP_Text m_TextComponent;
    public GameObject expDisplay;
    private void Awake()
    {
        xpValDisp = this;
        m_TextComponent = GetComponent<TMP_Text>();

    }
    private void OnEnable()
    {
        updateTxt(gameManager.gmInstance.player.experience, gameManager.gmInstance.player.level);
    }
    public void updateTxt(int xp, int level)
    {

        // m_TextComponent.text = "www";
        Debug.Log(xp+"xp:lvl"+ level);
        m_TextComponent.text = string.Format("{0}/{1}", xp, level*10);
        updateDisplay();
    }

    private void updateDisplay()
    {
        int x = gameManager.gmInstance.player.level;
        if (x == 0)
        {
            x = 1;
        }
        expDisplay.transform.localScale = new Vector3(((float)gameManager.gmInstance.player.experience / (x * 10)), 1, 1);
        //Debug.Log(((float)gameManager.gmInstance.player.experience / (x * 10)));
        //Debug.Log(gameManager.gmInstance.player.experience+" "+ x);

        //updateTxt(gameManager.gmInstance.player.experience, x * 10);
    }
}
