using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EffectAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Interface���p�����Ă���Component��Method���Ăяo��
        ExecuteEvents.Execute<IReceiveDamageEnemy>(
                    target: col.gameObject,     // �Ăяo���Ώۂ�Object
                    eventData: null,        // �C�x���g�f�[�^�i���W���[�����̏��j
                    functor: (target, eventData) => target.ReceiveDamage(10f));     // ����
    }
}
