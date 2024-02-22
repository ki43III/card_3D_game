using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_zoom : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {

        if (transform.parent.name != "left_zone" && transform.parent.name != "center_zone")
        {
            
        }


        if(transform.parent.name == "left_zone" )
        {
            
        }
        else if(transform.parent.name == "center_zone")
        {
           
        }
        else if(transform.parent.name == "Gage_erea")
        {

        }
        else if(transform.parent.name == "card_erea")
        {
            
            if (transform.localScale.x < 0.2f && mouse_ray_manage.isGrabbing == false)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.1f, gameObject.transform.localScale.y * 1.1f, gameObject.transform.localScale.z * 1.1f);
                card_alignment.alig_reset();
                
            }

            if (mouse_ray_manage.isGrabbing == false)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, 0.2f, gameObject.transform.localPosition.z);
            }
        }
        
    }

    private void OnMouseEnter()
    {
        if (transform.parent.name == "card_erea")
        {
            
        }
    }

    private void OnMouseExit()
    {
       
        if (transform.parent.name == "card_erea")
        {

            if (mouse_ray_manage.isGrabbing == false)
            {
                gameObject.transform.localScale = new Vector3(0.1f, 0.14285f, 0.14285f);
                gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.localPosition.z);
            }

            if (mouse_ray_manage.is_exis_left == false)
            {
                gameObject.transform.localScale = new Vector3(0.1f, 0.14285f, 0.14285f);
                gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.localPosition.z);

            }
            
        }



    }

}
