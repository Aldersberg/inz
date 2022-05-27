using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    string pName;
    private void Start()
    {
        pName = gameManager.gmInstance.playerName;
    }
    public void onWeaponChange(GameObject weapon)
    {   //set player weapon sprite to this one
        GameObject currentWeapon = GameObject.Find(pName).transform.GetChild(0).gameObject;
        gameManager.gmInstance.inventory.Add(currentWeapon);
        currentWeapon.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        GameObject currentWeapon1 = currentWeapon.transform.GetChild(0).gameObject;
        currentWeapon1.GetComponent<SpriteRenderer>().sprite = weapon.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;

        //transfer weapon stats
        currentWeapon.GetComponent<weapon>().damage = weapon.GetComponent<weapon>().damage;
        currentWeapon.GetComponent<weapon>().knockback = weapon.GetComponent<weapon>().knockback;
        currentWeapon.GetComponent<weapon>().boxCollider = weapon.GetComponent<weapon>().boxCollider;
        gameManager.gmInstance.inventory.Remove(weapon);

 
        gameManager.gmInstance.SaveState();
    }




    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverDescriptionManager.onHover("Damage: "+gameManager.gmInstance.inventory[0].GetComponent<weapon>().damage.ToString(), Input.mousePosition);
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
