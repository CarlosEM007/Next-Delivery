using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootMB : MonoBehaviour
{
    [Header("Gun Info")]
    [SerializeField] private GunInfoSO gunInfo;
    [SerializeField] private int smokeEmition;

    [Header("Input")]
    [SerializeField] private InputActionReference shootAction;

    [Header("Refence")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawner;

    [Header("Smoke")]
    [SerializeField] private ParticleSystem smokeParticles;

    [Header("SFX")]
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip reloadSound;

    private bool canShoot = true;

    private void OnEnable()
    {
        shootAction.action.Enable();
        shootAction.action.performed += Shoot;
    }

    private void OnDisable()
    {
        shootAction.action.Disable();
        shootAction.action.performed -= Shoot;
    }

    private void Start()
    {
        gunInfo.bullets = 8;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (!canShoot) return;

        if (gunInfo.bullets == 0)
        {
            StartCoroutine(PlayReload());
            return;
        }

        gunInfo.bullets -= 1;

        Instantiate(bulletPrefab, bulletSpawner.transform.position, bulletSpawner.transform.rotation);

        AudioManagerMB.Instance.PlaySFX(shotSound);
        StartCoroutine(PlayReload());

        smokeParticles.Play();
    }

    private IEnumerator PlayReload()
    {
        canShoot = false;
        AudioManagerMB.Instance.PlaySFX(reloadSound);

        yield return new WaitForSeconds(reloadSound.length);
        canShoot = true;
    }
}
