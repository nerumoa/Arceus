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
    float step = 800;
    float stepstart = 0;
    float stepstarttime = 0;
    float cooltimecount = 0;
    float cooltime = 120;
    private Rigidbody2D rb;
    private bool isGround = true;
    private Animator anim = null;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //クールタイム-------------------
        if (stepstart == 1)
        {
            stepstarttime = Time.frameCount;
            stepstart = 2;

        }
        if (stepstart == 2)
        {
            if (cooltimecount <= cooltime)
            {
                cooltimecount = Time.frameCount - stepstarttime;
            }
            else
            {
                stepstart = 0;
            }

        }

        //-------------------------------
        //左右移動-----------------------
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(2, 2, 2);
            anim.SetBool("walk", true);
            //ステップ-------------------
            if (Input.GetKeyDown(KeyCode.LeftShift) && stepstart == 0)
            {
                cooltimecount = 0;
                rb.AddForce(new Vector3(step, 0, 0));
                stepstart = 1;

            }
            //---------------------------
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(-2, 2, 2);
            anim.SetBool("walk", true);
            //ステップ-------------------
            if (Input.GetKeyDown(KeyCode.LeftShift) && stepstart == 0)
            {
                cooltimecount = 0;
                rb.AddForce(new Vector3(-step, 0, 0));
                stepstart = 1;

            }
            //---------------------------

        }
        else
        {
            anim.SetBool("walk", false);
        }
        //-------------------------------
        //ジャンプ-----------------------
        if (isGround)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                

                rb.AddForce(new Vector3(0, upForce, 0));

                jumpstart = Time.frameCount;
                Debug.Log("jumpstart: "+ jumpstart);

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpend = Time.frameCount;
                Debug.Log("jumpend: "+ jumpend);
                jumpframe = jumpend - jumpstart;
                Debug.Log("jumpframe: "+ jumpframe);

                if (jumpframe <= 8)
                {
                    rb.AddForce(new Vector3(0, -upForce/2, 0));
                }

                isGround = false;
            }

        }
        //-------------------------------


    }
    //接地判定---------------------------
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
            speed = 10;
        }
    }
    //-----------------------------------

}
