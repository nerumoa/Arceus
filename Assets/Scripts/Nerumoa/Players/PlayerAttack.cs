using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // プレイヤーの攻撃以外の情報も加える？

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Interfaceを取得
        var hit = col.gameObject.GetComponent<IReceiveDamageEnemy>();
        if (hit != null) {
            hit.ReceiveDamage(10f);
        }
    }
}
