using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, IReceiveDamageEnemy
{
    float HP = 100f;

    public void ReceiveDamage(float damage)
    {
        HP -= damage;
        Debug.Log("Enemy ��" + damage + "�_���[�W�H�����\nHP:" + HP);

        if (HP <= 0) {
            Destroy(gameObject);
        }
    }
}
