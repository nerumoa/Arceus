using UnityEngine.EventSystems;

/// <summary>
/// Player�̃_���[�W����
/// </summary>
public interface IReceiveDamagePlayer : IEventSystemHandler
{
    void ReceiveDamage(float damage);
}
