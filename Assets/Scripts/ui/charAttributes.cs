using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charAttributes : MonoBehaviour
{
    Player player;
    Text[] attributes;
    Button[] buttons;
    private void Awake()
    {
        player = gameManager.gmInstance.player;
        attributes = GetComponentsInChildren<Text>();
        buttons = GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(addStrength);
        buttons[1].onClick.AddListener(addVitality);
        buttons[2].onClick.AddListener(addSpeed);
    }
    private void OnEnable()
    {
        
        setStrengthTxt();
        setVitalityTxt();
        setSpeedTxt();
        
    }

    void setStrengthTxt()
    {
        attributes[0].text = "Strength: " + player.strength.ToString();
    }
    void addStrength()
    {

        player.strength += 1;
        setStrengthTxt();
        player.updateStr();
    }
    void setVitalityTxt()
    {
        attributes[1].text = "Vitality: " + player.vitalty.ToString();
    }
    void addVitality()
    {

        player.vitalty += 1;
        setVitalityTxt();
        player.updateVit();
    }
    void setSpeedTxt()
    {
        attributes[2].text = "Speed: " + player.speed.ToString();
    }
    void addSpeed()
    {

        player.speed += 1;
        setSpeedTxt();
        player.updateSpeed();
    }
}
