using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_right : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void card_call(GameObject on_Card)
    {
        GameObject onobeject = on_Card;
        Instantiate(onobeject, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.03f, transform.localPosition.z), Quaternion.Euler(0, 180, 0), this.gameObject.transform);

    }
}
