using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    //�ړ��X�s�[�h
    float speed = 5;

    // �ŏ��Ɉ�񂾂����s������
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    //������t���[�����ɌĂяo�����
    void Update()
    {
        //����D�L�[��������Ă���Ȃ�
        if (Input.GetKey(KeyCode.D))
        {
            //���݂̈ʒu���A���݂̈ʒu�{�ړ��������t���[�����Ԃɏ㏑������
            transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        //����A�L�[��������Ă���Ȃ�
        if (Input.GetKey(KeyCode.A))
        {
            //���݂̈ʒu���A���݂̈ʒu�{�ړ��������t���[�����Ԃɏ㏑������
            transform.position = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
