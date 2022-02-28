using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, IReceiveDamageEnemy
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Interface���擾
        var hit = col.gameObject.GetComponent<IReceiveDamagePlayer>();
        if (hit != null) {
            hit.ReceiveDamage(5f);
        }
    }
}
