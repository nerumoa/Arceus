using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    //�^�}���i�[����ϐ����G�f�B�^�[��ŕҏW�ł���悤�ɂ���
    public GameObject bullet;


    // Update is called once per frame
    void Update()
    {
        //�������N���b�N�������ꂽ��
        if (Input.GetMouseButtonDown(0))
        {
            //�e�����̃I�u�W�F�N�g�̈ʒu�ɕ�������B
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
