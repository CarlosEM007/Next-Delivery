using UnityEngine;
using UnityEngine.InputSystem;

public class ShootMB : MonoBehaviour
{
    [Header("Gun Info")]
    [SerializeField] private GunInfoSO gunInfo;

    [Header("Input")]
    [SerializeField] private InputActionReference shootAction;

    [Header("Refence")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawner;

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
    }

    private void NoAmmo()
    {

    }
}
