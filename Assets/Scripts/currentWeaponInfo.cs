using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currentWeaponInfo : MonoBehaviour
{

    Image[] image;
    SpriteRenderer[] weaponSprite;
    private TMP_Text damageTxt;
    private TMP_Text knockbackTxt;
    GameObject weapongo;

    private void Awake()
    {
        image = transform.GetComponentsInChildren<Image>(true);
        damageTxt = GetComponentsInChildren<TMP_Text>()[0];
        knockbackTxt = GetComponentsInChildren<TMP_Text>()[1];

    }
    public void showWeapon()
    {
        
        //Debug.Log(image.Length);
        weapongo = GameObject.Find("weapon");
        weaponSprite = weapongo.GetComponentsInChildren<SpriteRenderer>();
        //Debug.Log(weaponSprite.Length);
        image[0].sprite = weaponSprite[1].sprite;
        image[1].sprite = weaponSprite[0].sprite;
        //Debug.Log(GetComponentsInChildren<TMP_Text>().Length);
        damageTxt.text = "Damage: " + weapongo.GetComponent<weaponGO>().weapon.damage.ToString();
        knockbackTxt.text = "Knockback: " + weapongo.GetComponent<weaponGO>().weapon.knockback.ToString();
    }
    private void OnEnable()
    {
        showWeapon();
    }
}
