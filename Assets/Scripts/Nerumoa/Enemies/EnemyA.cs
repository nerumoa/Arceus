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
        Debug.Log("Enemy ��" + damage + "�_���[�W�H�����\nHP:" + HP);
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
        // Interface���p�����Ă���Component��Method���Ăяo��
        ExecuteEvents.Execute<IReceiveDamagePlayer>(
                    target: col.gameObject,     // �Ăяo���Ώۂ�Object
                    eventData: null,        // �C�x���g�f�[�^�i���W���[�����̏��j
                    functor: (target, eventData) => target.ReceiveDamage(10f));     // ����
    }
}
