using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // �v���C���[�̍U���ȊO�̏���������H

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Interface���擾
        var hit = col.gameObject.GetComponent<IReceiveDamageEnemy>();
        if (hit != null) {
            hit.ReceiveDamage(10f);
        }
    }
}
