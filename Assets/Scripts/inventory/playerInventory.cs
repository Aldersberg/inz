using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    string pName;
    Image[] image;
    SpriteRenderer[] weaponSprite;
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
    private void OnEnable()
    { 
        float x = 0;
        float offset = 388;
        float y = -32+offset;
        int i = 0;
        foreach(GameObject go in gameManager.gmInstance.inventory)
        {
            
            GameObject spriteObj = (GameObject)Instantiate(Resources.Load("Prefabs/inventoryItemSprite"));
            spriteObj.transform.SetParent(transform);
            RectTransform[] tmp = spriteObj.GetComponentsInChildren<RectTransform>(true);
            //spriteObj.transform.localPosition = Vector3.zero;
            
            image = spriteObj.GetComponentsInChildren<Image>(true);
            image[0].sprite = gameManager.gmInstance.inventory[i].GetComponentsInChildren<SpriteRenderer>()[0].sprite;
            image[1].sprite = gameManager.gmInstance.inventory[i].GetComponentsInChildren<SpriteRenderer>()[1].sprite;
            Debug.Log(x);
            //tmp[0].transform.position = Vector3.zero ;
            if (x < 400)
            {

                Debug.Log(i +x+ "<400");
                spriteObj.transform.localPosition = new Vector3(x, y, 1);// Camera.main.ScreenToWorldPoint;
            }
            if (x >= 400)
            {
                Debug.Log(i+x+">400");
                x = 0;
                y -= 100;
                spriteObj.transform.localPosition = new Vector3(x, y, 1); //Camera.main.ScreenToWorldPoint
            }
            x += 100; 
            i++;
            //tmp[1].transform.position = tmp[0].transform.position + new Vector3(32, 32, 1);
        }
    }
    private void OnDisable()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        //hoverDescriptionManager.onHover("Damage: "+gameManager.gmInstance.inventory[0].GetComponent<weapon>().damage.ToString(), Input.mousePosition);
        hoverDescriptionManager.onHover("Damage: ", Input.mousePosition);
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
