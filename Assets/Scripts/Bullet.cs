using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�ړ��X�s�[�h
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̈ʒu���A���݂̈ʒu�{�ړ��������t���[�����Ԃɏ㏑������
        transform.position = transform.position + new Vector3(speed, speed, 0) * Time.deltaTime;
    }
}
