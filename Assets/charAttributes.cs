using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charAttributes : MonoBehaviour
{
    Player player;
    Text[] attributes;
    Button[] buttons;
    private void OnEnable()
    {
        player = gameManager.gmInstance.player;
        attributes = GetComponentsInChildren<Text>();
        buttons = GetComponentsInChildren<Button>();
        setSpeedTxt();
        buttons[0].onClick.AddListener(addSpeed); 
    }
    void setSpeedTxt()
    {
        attributes[0].text = "Speed: " + player.speed.ToString();
    }
    void addSpeed()
    {

        player.speed += 1;
        setSpeedTxt();
        player.updateSpeed();
    }
}
