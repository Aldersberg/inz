using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hoverDescriptionManager : MonoBehaviour
{
    public TextMeshProUGUI descText;
    public RectTransform descWindow;

    public static Action<string, Vector3> onHover;
    //public static Action <Vector3> onHoverMove;
    public static Action onLeave;

    private void OnEnable()
    {
        onHover += showDesc;
        //onHoverMove += onMove;
        onLeave += hideDesc;
    }
    private void OnDisable()
    {
        onHover -= showDesc;
        //onHoverMove -= onMove;
        onLeave -= hideDesc;
    }
    void Start()
    {
        hideDesc();
    }

    void showDesc(string desc, Vector3 pos)
    {
        descText.text = desc;
        descWindow.sizeDelta = new Vector2(descText.preferredWidth, descText.preferredHeight);
        descWindow.transform.position = pos;
        descWindow.SetAsLastSibling();
        descWindow.gameObject.SetActive(true);
    }

    //void onMove(Vector3 mousePosition)
    //{
    //    
    //}

    void hideDesc()
    {
        descWindow.SetAsFirstSibling();
        descWindow.gameObject.SetActive(false);
    }

}
