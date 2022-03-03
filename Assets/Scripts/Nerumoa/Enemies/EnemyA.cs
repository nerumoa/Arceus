using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Interfaceを取得
        var hit = col.gameObject.GetComponent<IReceiveDamagePlayer>();
        if (hit != null) {
            hit.ReceiveDamage(5f);
        }
    }
}
