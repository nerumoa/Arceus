using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10;
    float upForce = 1000;
    float jumpstart = 0;
    float jumpend = 0;
    float jumpframe = 0;
    private Rigidbody2D rb;
    private bool isGround = true;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (isGround)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                

                rb.AddForce(new Vector3(0, upForce, 0));

                jumpstart = Time.frameCount;
                Debug.Log("jumpstart");
                Debug.Log(jumpstart);



            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpend = Time.frameCount;
                Debug.Log("jumpend");
                Debug.Log(jumpend);
                jumpframe = jumpend - jumpstart;
                Debug.Log("jumpframe");
                Debug.Log(jumpframe);

                if (jumpframe <= 8)
                {
                    rb.AddForce(new Vector3(0, -upForce/2, 0));
                }

                isGround = false;
            }

        }


    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
            speed = 10;
        }
    }

}
