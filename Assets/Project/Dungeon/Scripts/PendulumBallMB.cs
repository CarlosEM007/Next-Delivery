using UnityEngine;

public class PendulumBallMB : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float pushForce;
    [SerializeField] private float upForce;

    private void OnTriggerEnter(Collider other)
    {
        var knock = other.GetComponentInParent<IKnockback>();

        if (knock == null) return;

        Vector3 dir = other.transform.position - transform.position;

        dir.y = 0f;

        dir = dir.normalized;

        Vector3 force = dir * pushForce + Vector3.up * upForce;

        knock.applyKnockback(force);

    }
}
