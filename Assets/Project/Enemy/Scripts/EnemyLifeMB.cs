using System.Collections;
using UnityEngine;

public class EnemyLifeMB : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float life = 4f;

    [Header("Damage Effects")]
    [SerializeField] private GameObject FlashHitEffect;
    [SerializeField] private float FlashHitDuration = 0.5f;
    [SerializeField] private float knockbackResistance = 1f;
    [SerializeField] private ParticleSystem bloodEffect;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyBulletDamage(float damage)
    {
        life -= damage;

        if(life <= 0f)
        {
            StartCoroutine(ApplyHitStop());
        }
    }

    public void ApplyFlashHit()
    {
        StartCoroutine(startFlash());
    }

    private IEnumerator startFlash()
    {
        FlashHitEffect.SetActive(true);

        yield return new WaitForSeconds(FlashHitDuration);

        FlashHitEffect.SetActive(false);
    }

    public void ApplyKnockback(Vector3 direction, float knockbackForce)
    {
        if (rb == null) return;

        direction.y = 0f;
        direction = direction.normalized;

        float finalForce = knockbackForce / knockbackResistance;
        Vector3 force = direction * finalForce;

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(force, ForceMode.Impulse);
    }

    public void ApplyBloodEffect()
    {
        ParticleSystem blood = Instantiate(bloodEffect, transform.position, transform.rotation);

        blood.Emit(500);
    }

    private IEnumerator ApplyHitStop(float duration = 0.15f)
    {
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
