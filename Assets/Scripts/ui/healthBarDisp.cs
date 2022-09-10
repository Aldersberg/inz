using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class healthBarDisp : MonoBehaviour
{
    public static healthBarDisp hpBarDisp;
    private TMP_Text m_TextComponent;

    private void Awake()
    {
        hpBarDisp = this;
        m_TextComponent = GetComponent<TMP_Text>();

    }
    public void updateTxt(float hp, float maxHp)
    {

       // m_TextComponent.text = "www";
        m_TextComponent.text = string.Format("{0}/{1}", hp, maxHp);
    }
}
