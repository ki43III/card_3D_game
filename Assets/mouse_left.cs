using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_left : MonoBehaviour
{

    Transform child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).transform.localScale.x < 0.2f)
            {
                transform.GetChild(0).transform.localScale = new Vector3(0.2143589f, 0.3062117f, 0.3062117f);
            }
        }
    }

    public void card_call(GameObject on_Card)
    {

        GameObject onobeject = on_Card;
        if (on_Card.transform.localScale.x < 0.2f)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.1f, gameObject.transform.localScale.y * 1.1f, gameObject.transform.localScale.z * 1.1f);
        }
        Debug.Log(on_Card.transform.localScale.x);
        Instantiate(onobeject, new Vector3(transform.localPosition.x,transform.localPosition.y + 0.03f,transform.localPosition.z), Quaternion.Euler(0, 180, 0), this.gameObject.transform);
        
    }
}
