using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager gmInstance;
    public Player player;
    public string playerName;
    public List<GameObject> inventory;
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
    private void Start()
    {
        //playerInventory playerInventory = new playerInventory();
    }

    public int gold;
    public int exp;
    
    public void SaveState()
    {
        string save = "";
        List<GameObject> tmpInv = new List<GameObject>();
        foreach (GameObject go in inventory)
        {
            tmpInv.Add(go);
        }
        save += gold.ToString() + "|";
        save += exp.ToString()+"|";
        foreach(GameObject go in tmpInv)
        {
            save += go.name + "|";
            save += go.GetComponent<weapon>().damage.ToString() + "|";
            save += go.GetComponent<weapon>().knockback.ToString() + "|";
        }
        //gold,exp|prefab name, damage, knockback
        PlayerPrefs.SetString("saveState", save);
        tmpInv.Clear();
        Debug.Log("saved");
    }
    public void LoadState(Scene s, LoadSceneMode lsm)
    {
        if (!PlayerPrefs.HasKey("saveState"))
            return;
        string[] saveData = PlayerPrefs.GetString("saveState").Split('|');
        gold = int.Parse(saveData[0]);
        exp = int.Parse(saveData[1]);
        loadInventory(saveData);


        Debug.Log("loaded");
        player.transform.position = GameObject.Find("spawnPoint").transform.position;
        player.updateHp();
        //if (playerInventory.inventory.Count > 0) {
        //    foreach (GameObject a in playerInventory.inventory)
        //    {
        //        Debug.Log(a);
        //    }
        //}
        
    }
    public void loadInventory(string[] saveData)
    {
        if (saveData.Length > 2)
        {
            for (int i = 2; i < saveData.Length - 3; i += 3)
            {
                string tmpName = saveData[i].Substring(0, saveData[i].IndexOf('`') + 1);
                //Debug.Log(tmpName);
                GameObject tmpWeapon = (GameObject)Resources.Load("Prefabs/" + tmpName);
                tmpWeapon.GetComponent<weapon>().damage = float.Parse(saveData[i + 1]);
                tmpWeapon.GetComponent<weapon>().knockback = float.Parse(saveData[i + 1]);
                inventory.Add(tmpWeapon);
            }
        }
    }
    public floatingTextManager floatingTextManager;
    public void showText(string text, int fontSize, Color txtColor, Vector3 position, Vector3 motion, float duration, bool shading)
    {
        floatingTextManager.showText(text, fontSize, txtColor, position, motion, duration,shading);
    }
}
