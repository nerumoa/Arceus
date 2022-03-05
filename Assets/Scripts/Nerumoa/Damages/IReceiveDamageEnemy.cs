using UnityEngine.EventSystems;

/// <summary>
/// Enemy‚Ìƒ_ƒ[ƒW”»’è
/// </summary>
public interface IReceiveDamageEnemy : IEventSystemHandler
{
    void ReceiveDamage(float damage);
}
