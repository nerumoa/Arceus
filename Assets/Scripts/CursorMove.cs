using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMove : MonoBehaviour
{
    private Vector3 mouse;
    private Vector3 target;
    private Vector3 after;
    float start = 0;
    float starttime = 0;
    float count = 0;
    float rad = 0;
    float degree = 0;
    float beforex = 0;
    float beforey = 0;
    float deltax = 0;
    float deltay = 0;
    float rotation = 0;
    private Animator anim = null;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == 0)
        {
            starttime = Time.frameCount;
            beforex = mouse.x;
            beforey = mouse.y;
            start = 1;
        }
        if (start == 1)
        {
            if (count <= 1)
            {
                count = Time.frameCount - starttime;
            }
        }
        if (count == 1)
        {
            deltax = mouse.x - beforex;
            deltay = mouse.y - beforey;
            rad = Mathf.Atan2(deltax, deltay);
            degree = rad * Mathf.Rad2Deg;

            start = 0;

        }



        if (deltax != 0 || deltay != 0)
        {

            if (degree <= 0)
            {
                rotation = 360 + degree;
            }
            else
            {
                rotation = degree;
            }

            rotation -= 45;
        }
        anim.SetBool("move", true);
        transform.rotation = Quaternion.Euler(0, 0, -rotation);
        mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));

        this.transform.position = target;
    }
}
