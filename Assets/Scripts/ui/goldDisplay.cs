using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class goldDisplay : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    private void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();

    }
    private void OnEnable()
    {
        m_TextComponent.text = gameManager.gmInstance.gold.ToString();
    }
}
