using UnityEngine.EventSystems;

/// <summary>
/// Enemy�̃_���[�W����
/// </summary>
public interface IReceiveDamageEnemy : IEventSystemHandler
{
    void ReceiveDamage(float damage);
}
