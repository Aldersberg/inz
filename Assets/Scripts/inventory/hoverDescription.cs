using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int invId;
    public string description;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(gameManager.gmInstance.inventory[invId].name);
        String name = gameManager.gmInstance.inventory[invId].name.Substring(0, 6);
        if (name == "weapon")
        {
            description += "Damage: "+gameManager.gmInstance.inventory[invId].GetComponent<weaponGO>().weapon.damage + "\n";
        }
        //hoverDescriptionManager.onHover("Damage: "+gameManager.gmInstance.inventory[0].GetComponent<weapon>().damage.ToString(), Input.mousePosition);
        hoverDescriptionManager.onHover(description, Input.mousePosition);
        description = "";
        //Debug.Log(eventData.pointerEnter);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverDescriptionManager.onLeave();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(PointerEventData.InputButton.Right);
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log(eventData.pointerPress);
            //gameManager.gmInstance.inventory.RemoveAt(eventData.pointerPress.GetComponent<hoverDescription>().invId);
            //gameManager.gmInstance.SaveState();

            playerInventory tmp = transform.GetComponentInParent<playerInventory>();
            tmp.onWeaponChange(gameManager.gmInstance.inventory.ElementAt(eventData.pointerPress.GetComponent<hoverDescription>().invId));
            GameObject.Find("CurrentWeapon").GetComponent<currentWeaponInfo>().showWeapon();
            //tmp.refreshInventoryObjects();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
            weaponUpgradeWindow tmp1 = transform.parent.parent.GetComponentInChildren<weaponUpgradeWindow>(true);
            //Debug.Log(tmp1);
            tmp1.showWeapon(gameManager.gmInstance.inventory.ElementAt(eventData.pointerPress.GetComponent<hoverDescription>().invId));
            
        }
        if (eventData.button == PointerEventData.InputButton.Middle)
        {
            //Debug.Log(eventData.pointerPress);
            gameManager.gmInstance.inventory.Clear();
            gameManager.gmInstance.SaveState();
            playerInventory tmp = transform.GetComponentInParent<playerInventory>();
            tmp.refreshInventoryObjects();
        }
        //Debug.Log(eventData.button);
        //else if(Input.GetMouseButton(1))
        //    Debug.Log("rightclick");
    }

    
}
