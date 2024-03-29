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
    Button upgradeButton;
    GameObject weapongo;

    private void Awake()
    {
        image = transform.GetComponentsInChildren<Image>(true);
        damageTxt = GetComponentsInChildren<TMP_Text>()[0];
        knockbackTxt = GetComponentsInChildren<TMP_Text>()[1];
        upgradeButton = GetComponentInChildren<Button>();
        upgradeButton.onClick.AddListener(upgradeWeaponButton);
        toggleChildren(false);

    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        toggleChildren(false);
    }
    public void showWeapon(GameObject weaponGO)
    {
        toggleChildren(true);
        //Debug.Log(image.Length);
        weapongo = weaponGO;
        weaponSprite = weaponGO.GetComponentsInChildren<SpriteRenderer>();
        //Debug.Log(weaponSprite.Length);
        image[1].sprite = weaponSprite[1].sprite;
        image[2].sprite = weaponSprite[0].sprite;
        //Debug.Log(GetComponentsInChildren<TMP_Text>().Length);
        updateDescriptionStats(weaponGO);
    }
    void updateDescriptionStats(GameObject weaponGO)
    {
        damageTxt.text = "Damage: " + weaponGO.GetComponent<weaponGO>().weapon.damage.ToString();
        knockbackTxt.text = "Knockback: " + weaponGO.GetComponent<weaponGO>().weapon.knockback.ToString();
    }

    void upgradeWeaponButton()
    {
        Debug.Log("upgrade clicked");
        upgradeWeapon(weapongo.GetComponent<weaponGO>().weapon);
        updateDescriptionStats(weapongo);
        gameManager.gmInstance.SaveState();
    }
    public void upgradeWeapon(weapon weapon)
    {
        weapon.damage += 100;
        Debug.Log("upgraded");
    }
    void toggleChildren(bool state)
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }
}
