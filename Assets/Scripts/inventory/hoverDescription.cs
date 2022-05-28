using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int invId;
    public string description;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //hoverDescriptionManager.onHover("Damage: "+gameManager.gmInstance.inventory[0].GetComponent<weapon>().damage.ToString(), Input.mousePosition);
        hoverDescriptionManager.onHover("id: "+invId.ToString(), Input.mousePosition);
        Debug.Log("enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverDescriptionManager.onLeave();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
    }

    
}
