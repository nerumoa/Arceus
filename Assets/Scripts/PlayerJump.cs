using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    //�W�����v�̂��
    public float jumpPower;
    private Rigidbody2D rb;
    //���W�����v������W�����؂ł��Ȃ�����
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }
    }
    //�n�ʂɒ��n������܂��W�����v�ł���悤�ɂ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { 
            isJumping = false;
        }
    }
}
