using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    public List<floatingText> floatingTexts = new List<floatingText>();
    
    private floatingText getFloatingText()
    {
        floatingText getTxt = floatingTexts.Find(t => !t.active);
        if (getTxt == null)
        {   
            //if didn't find a spare one
            getTxt = new floatingText();
            getTxt.go = Instantiate(textPrefab);
            getTxt.go.transform.SetParent(textContainer.transform);
            getTxt.text = getTxt.go.GetComponent<Text>();
            floatingTexts.Add(getTxt);
        }

        return getTxt;
    }

    public void showText(string text, int fontSize, Color txtColor, Vector3 position, Vector3 motion, float duration, bool shading)
    {
        floatingText floatingText = getFloatingText();
        Vector3 floatingPos = new Vector3(position.x, position.y + 0.14f, 2);

        

        floatingText.text.text = text;
        floatingText.text.fontSize = fontSize;
        floatingText.text.color = txtColor;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(floatingPos);
        floatingText.motion = motion;
        floatingText.duration = duration;
        
        floatingText.Show();
        if (shading)
            shadeText(floatingText, floatingPos);
        //if (shading)
        //{
        //
        //    floatingText floatingShade = getFloatingText();
        //    floatingShade.text.text = text;
        //    floatingShade.text.fontSize = fontSize;
        //    floatingShade.text.color = Color.black;
        //    Vector3 tmp = Camera.main.WorldToScreenPoint(floatingPos);
        //    //Vector3 shadingPos = new Vector3(position.x + 0.003f, position.y + 0.14f, position.z);
        //    Vector3 shadingPos = new Vector3(floatingPos.x, floatingPos.y, position.z);
        //    floatingShade.go.transform.position = Camera.main.WorldToScreenPoint(shadingPos);
        //    floatingShade.motion = motion;
        //    floatingShade.duration = duration;
        //
        //    floatingShade.Show();
        //}



    }
    void shadeText(floatingText toShade, Vector3 floatingPos)
    {
        floatingText floatingShade = getFloatingText();
        floatingShade.text.text = toShade.text.text;
        floatingShade.text.fontSize = toShade.text.fontSize;
        floatingShade.text.color = Color.black;
        Vector3 tmp = Camera.main.WorldToScreenPoint(floatingPos);
        //Vector3 shadingPos = new Vector3(position.x + 0.003f, position.y + 0.14f, position.z);
        Vector3 shadingPos = new Vector3(floatingPos.x - floatingPos.x * 0.002f, floatingPos.y, 1);
        floatingShade.go.transform.position = Camera.main.WorldToScreenPoint(shadingPos);
        floatingShade.motion = toShade.motion;
        floatingShade.duration = toShade.duration;
        floatingShade.go.transform.SetSiblingIndex(0);
        floatingShade.Show();
    }

    private void Update()
    {
        foreach(floatingText f in floatingTexts)
        {
            f.updateFloatingText();
        }
    }
}
