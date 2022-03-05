using UnityEngine.EventSystems;

/// <summary>
/// Player‚Ìƒ_ƒ[ƒW”»’è
/// </summary>
public interface IReceiveDamagePlayer : IEventSystemHandler
{
    void ReceiveDamage(float damage);
}
