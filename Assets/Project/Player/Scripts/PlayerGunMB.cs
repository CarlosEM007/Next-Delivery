using UnityEngine;

public class PlayerGunMB : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private EquipGunMB equipGunEvent;

    [Header("Gun")]
    [SerializeField] private GameObject Gun;

    private void OnEnable() => equipGunEvent.gunEquipedEvent += ActiveGun;
    private void OnDisable() => equipGunEvent.gunEquipedEvent -= ActiveGun;

    private void ActiveGun()
    {
        Gun.SetActive(true);
    }
}
