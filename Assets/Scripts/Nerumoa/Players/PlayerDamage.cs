using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, IReceiveDamagePlayer
{
    float HP = 100f;

    public void ReceiveDamage(float damage)
    {
        HP -= damage;
        Debug.Log("Player は" + damage + "ダメージ食らった\nHP:" + HP);
    }
}
