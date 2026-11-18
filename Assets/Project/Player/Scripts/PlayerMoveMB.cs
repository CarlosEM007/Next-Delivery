using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveMB : MonoBehaviour, IKnockback
{
    [Header("Input")]
    [SerializeField] private InputActionReference walkAction;

    [Header("Player Info")]
    [SerializeField] private PlayerInfoSO playerInfo;

    private CharacterController characterController;
    private PlayerLookMB playerLook;
    private float verticalSpeed;

    private Vector3 vectorForce;
    private float knockbackDecay = 8f;

    private bool cantMove = false;

    public Vector3 knockback {
        get => vectorForce;
        set => vectorForce = value;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerLook = GetComponent<PlayerLookMB>();
    }

    private void OnEnable() => walkAction.action.Enable();
    private void OnDisable() => walkAction.action.Disable();

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (cantMove) return;

        Vector2 input = walkAction.action.ReadValue<Vector2>();

        Vector3 direction = transform.forward * input.y + transform.right * input.x;
        Vector3 displacement = (direction * playerInfo.speed) + knockback;


        if (characterController.isGrounded && verticalSpeed < 0f)
            verticalSpeed = playerInfo.stayGroundForce;

        verticalSpeed += playerInfo.gravity * Time.deltaTime;
        displacement.y = verticalSpeed;

        knockback = Vector3.Lerp(knockback, Vector3.zero, knockbackDecay * Time.deltaTime);

        characterController.Move(displacement * Time.deltaTime);
    }

    public void applyKnockback(Vector3 force)
    {
        verticalSpeed = force.y;
        force.y = 0f;

        vectorForce = force;
    }

    public IEnumerator StopPlayer(float time)
    {
        characterController.enabled = false;
        playerLook.enabled = false;
        cantMove = true;

        yield return new WaitForSeconds(time);

        characterController.enabled = true;
        playerLook.enabled = true;
        cantMove = false;
    }
}
