using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player����̍U������
/// Player��Enemy��interface�𕪂���ׂ����s���Ȃ��߁A��芸����������
/// </summary>
public interface IReceiveDamageEnemy
{
    void ReceiveDamage(float damage);
}
