using Unity.VisualScripting;
using UnityEngine;

public class BulletMB : MonoBehaviour, IBullet
{
    [Header("Bullet Info")]
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;

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
        if (other.CompareTag("Enemy") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
