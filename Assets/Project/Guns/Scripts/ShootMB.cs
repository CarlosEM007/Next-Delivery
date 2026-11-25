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
        if (gunInfo.bullets == 0)
        {
            NoAmmo();
            return;
        }


        gunInfo.bullets -= 1;

        Instantiate(bulletPrefab, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        smokeParticles.Play();

        AudioManagerMB.Instance.PlaySFX(shotSound);
    }

    private void NoAmmo()
    {

    }
}
