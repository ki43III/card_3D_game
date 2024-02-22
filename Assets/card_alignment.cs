using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class card_alignment : MonoBehaviour
{

    public GameObject Cards;
    static public GameObject card_zone;
    //Transform parent;

    
    // Start is called before the first frame update
    void Start()
    {
        card_zone = GameObject.Find("card_erea");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Cards,this.transform.position,Quaternion.Euler(50,180,0),this.gameObject.transform);
            alig();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(DelayCoroutine(0.1f, () =>
            {
                // 0.1秒後にここの処理が実行される
                alig();
            }));
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "stage")
                {
                    alig_small();
                }
            }
        }
    }

    public void alig()
    {
        float i = this.transform.position.x - 5;
        foreach (Transform child in gameObject.transform)
        {
            i++;
            child.transform.position = new Vector3(i, child.transform.position.y,transform.position.z);

        }
    }

    static public void alig_reset()
    {
        
        float i = -5;
        foreach (Transform child in card_zone.transform)
        {
            i++;
            child.transform.position = new Vector3(i,5, -5.15f);
            
        }
    }

    public void alig_small()
    {
        float i = this.transform.position.x - 5;
        float j = this.transform.position.y - 4;
        foreach (Transform child in gameObject.transform)
        {
            i++;
            child.transform.position = new Vector3(i, j, transform.position.z);
        }
    }


    public void left_scro()
    {
        
        transform.position =new Vector3(this.transform.position.x - 1,this.transform.position.y,this.transform.position.z);
    }

    public void right_scro()
    {   
        transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
    }

    //遅延子ルーチン用
    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
