using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponImage : MonoBehaviour
{
    Image[] image;
    public GameObject weaponObj;
    SpriteRenderer[] weaponSprite;

    protected virtual void Awake()
    {
        image = transform.GetComponentsInChildren<Image>(true);
    }
    protected virtual void Start()
    {
        weaponObj = GameObject.Find("weapon");
        weaponSprite = weaponObj.GetComponentsInChildren<SpriteRenderer>();
        Debug.Log(weaponSprite.Length);
        image[0].sprite = weaponSprite[0].sprite;
        image[1].sprite = weaponSprite[1].sprite;
        //transform.GetComponentInChildren<Image>(true).sprite = weaponObj.GetComponentInChildren<SpriteRenderer>().sprite;
       
        //childImg.sprite = weaponObj.GetComponentInChildren<SpriteRenderer>().sprite;
        //Debug.Log(weaponObj.GetComponentInChildren<SpriteRenderer>());
        //Debug.Log(weaponObj.GetComponent<SpriteRenderer>());
    }

    private void OnEnable()
    {
        
            
        //some weapon template
    }
}
