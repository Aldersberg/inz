using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hoverDescriptionManager : MonoBehaviour
{
    public TextMeshProUGUI descText;
    public RectTransform descWindow;

    public static Action<string, Vector2> onHover;
    public static Action onLeave;

    private void OnEnable()
    {
        onHover += showDesc;
        onLeave += hideDesc;
    }
    private void OnDisable()
    {
        onHover -= showDesc;
        onLeave -= hideDesc;
    }
    void Start()
    {
        hideDesc();
    }

    void showDesc(string desc, Vector2 pos)
    {
        descText.text = desc;
        descWindow.sizeDelta = new Vector2(descText.preferredWidth, descText.preferredHeight);
        descWindow.transform.position = pos;
        descWindow.gameObject.SetActive(true);
    }
    void hideDesc()
    {
        descWindow.gameObject.SetActive(false);
    }

}
