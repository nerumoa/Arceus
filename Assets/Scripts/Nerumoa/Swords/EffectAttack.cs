using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Interface���擾
        var hit = col.GetComponent<IReceiveDamageEnemy>();
        if (hit != null) {
            hit.ReceiveDamage(10f);
        }
    }
}
