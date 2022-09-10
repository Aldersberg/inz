using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class expValDisplay : MonoBehaviour
{
    public static expValDisplay xpValDisp;
    private TMP_Text m_TextComponent;

    private void Awake()
    {
        xpValDisp = this;
        m_TextComponent = GetComponent<TMP_Text>();

    }
    public void updateTxt(int xp, int level)
    {

        // m_TextComponent.text = "www";
        m_TextComponent.text = string.Format("{0}/{1}", xp, level);
    }
}
