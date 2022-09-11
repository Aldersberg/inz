using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class weaponUpgradeWindow : MonoBehaviour
{
    Image[] image;
    SpriteRenderer[] weaponSprite;
    private TMP_Text damageTxt;
    private TMP_Text knockbackTxt;

    private void Awake()
    {
        image = transform.GetComponentsInChildren<Image>(true);
        damageTxt = GetComponentsInChildren<TMP_Text>()[0];
        knockbackTxt = GetComponentsInChildren<TMP_Text>()[1];
    }
    public void showWeapon(GameObject weaponGO)
    {
        Debug.Log(image.Length);
        weaponSprite = weaponGO.GetComponentsInChildren<SpriteRenderer>();
        //Debug.Log(weaponSprite.Length);
        image[1].sprite = weaponSprite[1].sprite;
        image[2].sprite = weaponSprite[0].sprite;
        Debug.Log(GetComponentsInChildren<TMP_Text>().Length);
        damageTxt.text = "Damage: " + weaponGO.GetComponent<weapon>().damage.ToString();
        knockbackTxt.text = "Knockback: " + weaponGO.GetComponent<weapon>().knockback.ToString();
    }
}
