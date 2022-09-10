using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour
{
    string pName;
    
    SpriteRenderer[] weaponSprite;
    private void Start()
    {   
        pName = gameManager.gmInstance.playerName;

        //gameManager.gmInstance.player.initExp();

    }
    public void onWeaponChange(GameObject weapon)
    {   
        //set player weapon sprite to this one
        GameObject currentWeapon = GameObject.Find(pName).transform.GetChild(0).gameObject;
        //gameManager.gmInstance.inventory.Add(currentWeapon);
        currentWeapon.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        GameObject currentWeapon1 = currentWeapon.transform.GetChild(0).gameObject;
        currentWeapon1.GetComponent<SpriteRenderer>().sprite = weapon.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;

        //transfer weapon stats
        currentWeapon.GetComponent<weapon>().damage = weapon.GetComponent<weapon>().damage;
        currentWeapon.GetComponent<weapon>().knockback = weapon.GetComponent<weapon>().knockback;
        currentWeapon.GetComponent<weapon>().boxCollider = weapon.GetComponent<weapon>().boxCollider;
        //gameManager.gmInstance.inventory.Remove(weapon);

 
        gameManager.gmInstance.SaveState();
    }
    
    public void loadIventoryObjects()
    {
        string[] saveData = PlayerPrefs.GetString("saveState").Split('|');
        gameManager.gmInstance.inventory.Clear();
        gameManager.gmInstance.loadInventory(saveData);
        Image[] image;
        float x = 20;
        float offsetY = 388;
        float y = -32 + offsetY;
        int i = 0;
        foreach (GameObject go in gameManager.gmInstance.inventory)
        {

            GameObject spriteObj = (GameObject)Instantiate(Resources.Load("Prefabs/inventoryItemSpriteWB"));
            spriteObj.transform.SetParent(transform);
            spriteObj.gameObject.SetActive(true);
            //RectTransform[] tmp = spriteObj.GetComponentsInChildren<RectTransform>(true);


            image = spriteObj.GetComponentsInChildren<Image>(true);
            //Debug.Log(image.Length);
            image[image.Length - 2].sprite = gameManager.gmInstance.inventory[i].GetComponentsInChildren<SpriteRenderer>()[0].sprite;
            image[image.Length - 1].sprite = gameManager.gmInstance.inventory[i].GetComponentsInChildren<SpriteRenderer>()[1].sprite;

            spriteObj.GetComponent<hoverDescription>().invId = i;
            //spriteObj.GetComponent<hoverDescription>().description = i;
            //tmp[0].transform.position = Vector3.zero ;
            if (x < 420)
            {

                //Debug.Log(i +x+ "<400");
                spriteObj.transform.localPosition = new Vector3(x, y, 1);// Camera.main.ScreenToWorldPoint;
            }
            if (x >= 420)
            {
                //Debug.Log(i+x+">400");
                x = 20;
                y -= 150;
                spriteObj.transform.localPosition = new Vector3(x, y, 1); //Camera.main.ScreenToWorldPoint
            }
            x += 100;
            i++;
            //tmp[1].transform.position = tmp[0].transform.position + new Vector3(32, 32, 1);
        }
    }

    void destroyInventoryObjects()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).name!="DescriptionWindow")
                    Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
    public void refreshInventoryObjects()
    {
        destroyInventoryObjects();
        loadIventoryObjects();

    }
    private void OnEnable()
    {
        loadIventoryObjects();
    }

    private void OnDisable()
    {
        destroyInventoryObjects();
    }



    
}
