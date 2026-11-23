using Unity.VisualScripting;
using UnityEngine;

public class BulletMB : MonoBehaviour, IBullet
{
    [Header("Bullet Info")]
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float weaponKnockbackForce = 12f;

    public float BulletDamage
    {
        get { return bulletDamage; }
        set { bulletDamage = value; }
    }

    public float BulletSpeed
    {
        get { return bulletSpeed; }
        set { bulletSpeed = value; }
    }

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        transform.position += transform .forward * BulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyLifeMB>(out EnemyLifeMB enemy))
        {
            enemy.ApplyKnockback(transform.forward, weaponKnockbackForce);
            enemy.ApplyFlashHit();
            enemy.ApplyBulletDamage(bulletDamage);
            enemy.ApplyBloodEffect();

            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
