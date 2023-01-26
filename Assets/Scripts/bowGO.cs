using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowGO : MonoBehaviour
{
    [SerializeField]
    float damage=1f;
    [SerializeField]
    float knockback;
    [SerializeField]
    float cooldown;
    [SerializeField]
    float arrowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePosition - transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log(angle);
            
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePosition - transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log(angle);

            GameObject arrow = (GameObject)Instantiate(Resources.Load("Prefabs/arrow"));
            arrow.transform.parent = transform; 
            arrow.transform.position = transform.position;
            arrow.transform.eulerAngles = new Vector3(0, 0, angle);
            arrow.GetComponent<arrowGO>().destination = new Vector2((float)Math.Round(mousePosition.x,2), (float)Math.Round(mousePosition.y, 2));
            arrow.GetComponent<arrowGO>().damage = damage;
            Debug.Log("bowgo");
        }
    }
}
