using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    //�^�}���i�[����ϐ����G�f�B�^�[��ŕҏW�ł���悤�ɂ���
    public GameObject bullet;
    float speed = 10;
   


    // Update is called once per frame
    void Update()
    {
        //�������N���b�N�������ꂽ��
        //����ł�
        if (Input.GetMouseButtonDown(0))
        {
            //�e�̍쐬
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
            // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �����̐����iZ�����̏����Ɛ��K���j
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

            // �e�ɑ��x��^����
            clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
        }
    }
}
