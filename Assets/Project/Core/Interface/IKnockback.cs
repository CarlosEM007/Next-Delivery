using UnityEngine;

public interface IKnockback
{
    Vector3 knockback { get; set; }

    public void applyKnockback(Vector3 force);
}
