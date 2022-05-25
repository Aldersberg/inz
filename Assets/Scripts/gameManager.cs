using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager gmInstance;
    public Player player;
    public string playerName;
    private void Awake()
    {
        if (player != null)
        {
            playerName = player.transform.name;
        }

        if (gameManager.gmInstance != null)
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
            return;
        }
        Debug.Log("awake");
        gmInstance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(floatingTextManager);
    }
    

    public int gold;
    public int exp;
    
    public void SaveState()
    {
        string save = "";
        save += gold.ToString() + "|";
        save += exp.ToString();
        PlayerPrefs.SetString("saveState", save);
        Debug.Log("saved");
    }
    public void LoadState(Scene s, LoadSceneMode lsm)
    {
        if (!PlayerPrefs.HasKey("saveState"))
            return;
        string[] saveData = PlayerPrefs.GetString("saveState").Split('|');
        gold = int.Parse(saveData[0]);
        exp = int.Parse(saveData[1]);
        Debug.Log("loaded");
        player.transform.position = GameObject.Find("spawnPoint").transform.position;
        player.updateHp();
    }
    public floatingTextManager floatingTextManager;
    public void showText(string text, int fontSize, Color txtColor, Vector3 position, Vector3 motion, float duration, bool shading)
    {
        floatingTextManager.showText(text, fontSize, txtColor, position, motion, duration,shading);
    }
}
