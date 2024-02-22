using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class mouse_ray_manage : MonoBehaviour
{
    public static bool isGrabbing;
    
    Plane plane;
    Transform cube;
    public static int gage_counts = 0;
    public bool is_up_gage = false;

    public static bool is_exis_left = false;
    public static bool is_exis_center = false;
    public static bool is_exis_right = false;
    
    public mouse_left Left_task;
    public mouse_center Center_task;
    public mouse_right Right_task;

    public TextMeshPro gage_count;
    public TextMeshProUGUI zone_text;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(new Vector3(0,1,0),new Vector3(0,2,0));
    }

    // Update is called once per frame
    void Update()
    {

        bool Card_hit = false;
        bool gage_hit = false;
        bool left_hit = false;
        bool center_hit = false;
        bool right_hit = false;
        if (Input.GetMouseButton(0))
        {
            Ray ray_M = Camera.main.ScreenPointToRay(Input.mousePosition);
            foreach (RaycastHit hit_M in Physics.RaycastAll(ray_M))
            {
                if (hit_M.collider.tag == "stage")
                {
                    zone_text.text = "";
                }

                if (hit_M.collider.tag == "Card")
                {
                    Card_hit = true;
                }

                if (hit_M.collider.tag == "gage")
                {
                    gage_hit = true;
                   
                }
                if(hit_M.collider.tag == "left")
                {
                    left_hit = true;
                }
                if(hit_M.collider.tag == "center")
                {
                    center_hit = true;
                    
                }
                if(hit_M.collider.tag == "right")
                {
                    right_hit = true;
                }
            }

            if (gage_hit == true && Card_hit == true)
            {
                is_up_gage = true;
                zone_text.text = "gage";
            }
            else
            {
                is_up_gage = false;
                
            }

            if(left_hit == true && Card_hit == true)
            {
                is_exis_left = true;
                zone_text.text = "left";
            }
            else
            {
                is_exis_left = false;
            }

            if(center_hit == true && Card_hit == true)
            {
                is_exis_center = true;
                zone_text.text = "center";
            }
            else
            {
                is_exis_center = false;
            }

            if(right_hit == true && Card_hit == true)
            {
                is_exis_right = true;
                zone_text.text = "right";
            }
            else
            {
                is_exis_right = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Card")
                {
                    isGrabbing = true;

                    if (transform.localScale.x < 0.2f)
                    {
                        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.1f, gameObject.transform.localScale.y * 1.1f, gameObject.transform.localScale.z * 1.1f);
                    }

                    cube = hit.transform;

                }
            }
        }


        if (isGrabbing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            plane.Raycast(ray, out rayDistance);

            cube.position = ray.GetPoint(rayDistance);

            if (Input.GetMouseButtonUp(0))
            {
                isGrabbing = false;
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (is_up_gage == true)
            {
                gage_counts++;
                gage_count.text = gage_counts.ToString();
                Debug.Log("gage++");


                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.tag == "Card")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }

                is_up_gage = false;
            }

            if(is_exis_left == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.tag == "Card")
                    {
                        GameObject target_obj = hit.collider.gameObject;
                        Left_task.card_call(target_obj);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }

            if(is_exis_center == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.tag == "Card")
                    {
                        GameObject target_obj = hit.collider.gameObject;
                        StartCoroutine(DelayCoroutine(0.01f, () =>
                        {
                            // 0.1秒後にここの処理が実行される
                            Center_task.card_call(target_obj);
                            Destroy(hit.collider.gameObject);
                        }));

                        
                        
                    }
                }
            }

            if (is_exis_right == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.tag == "Card")
                    {
                        GameObject target_obj = hit.collider.gameObject;
                        StartCoroutine(DelayCoroutine(0.01f, () =>
                        {
                            // 0.1秒後にここの処理が実行される
                            Right_task.card_call(target_obj);
                            Destroy(hit.collider.gameObject);
                        }));

                    }
                }
            }

        }
    }







    //遅延子ルーチン用
    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
