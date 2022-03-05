using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EffectAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Interfaceを継承しているComponentのMethodを呼び出し
        ExecuteEvents.Execute<IReceiveDamageEnemy>(
                    target: col.gameObject,     // 呼び出す対象のObject
                    eventData: null,        // イベントデータ（モジュール等の情報）
                    functor: (target, eventData) => target.ReceiveDamage(10f));     // 操作
    }
}
