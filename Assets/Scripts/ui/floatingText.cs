using UnityEngine;
using UnityEngine.UI;

public class floatingText 
{
    public bool active;
    public GameObject go;
    public Text text;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public Vector3 origin;
    public Vector3 movement;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void updateFloatingText()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
            Hide();

        // Debug.Log("transform: "+go.transform.position);
        //go.transform.position += 5;
       go.transform.position += motion * Time.deltaTime;
        //Vector3 tmp = Camera.main.WorldToScreenPoint(player.position);
        ////Debug.Log("tmp: "+tmp);
        //float dx = tmp.x - go.transform.position.x;
        //float dy = tmp.y - go.transform.position.y;
        //go.transform.position += new Vector3(dx, dy + (motion.y * Time.deltaTime), 0);
        // text pos - cam pos change


    }
}
