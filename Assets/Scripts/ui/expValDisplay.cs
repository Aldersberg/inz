using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class expValDisplay : MonoBehaviour
{
    public static expValDisplay xpValDisp;
    [SerializeField]
    GameObject LevelTXTGO;
    private TMP_Text LevelTXT;
    private TMP_Text xpValues;
    public GameObject expDisplay;
    private void Awake()
    {
        xpValDisp = this;
        xpValues = GetComponents<TMP_Text>()[0];
        LevelTXT = LevelTXTGO.transform.GetComponent<TMP_Text>();
        Debug.Log(GetComponents<TMP_Text>().Length);

    }
    private void OnEnable()
    {
        updateTxt(gameManager.gmInstance.player.experience, gameManager.gmInstance.player.level);
    }
    public void updateTxt(int xp, int level)
    {

        // m_TextComponent.text = "www";
        Debug.Log(xp+"xp:lvl"+ level);
        LevelTXT.text = string.Format("Level: {0}", level);
        xpValues.text = string.Format("{0}/{1}", xp, level*10);
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
