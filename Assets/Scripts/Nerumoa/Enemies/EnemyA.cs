using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyA : MonoBehaviour, IReceiveDamageEnemy
{
    float HP = 100f;
    new AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ReceiveDamage(float damage)
    {
        HP -= damage;
        Debug.Log("Enemy は" + damage + "ダメージ食らった\nHP:" + HP);
        if (damage > 0f) {
            audio.time = 0.05f;
            audio.Play();
        }

        if (HP <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Interfaceを継承しているComponentのMethodを呼び出し
        ExecuteEvents.Execute<IReceiveDamagePlayer>(
                    target: col.gameObject,     // 呼び出す対象のObject
                    eventData: null,        // イベントデータ（モジュール等の情報）
                    functor: (target, eventData) => target.ReceiveDamage(10f));     // 操作
    }
}
