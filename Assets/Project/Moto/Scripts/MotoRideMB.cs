using UnityEngine;
using UnityEngine.InputSystem;

public class MotoRideMB : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference walkAction;

    [Header("Moto Info")]
    [SerializeField] private MotoSO motoInfo;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip motoStop;
    [SerializeField] private AudioClip motoRiding;

    private AudioSource audioSource;

    private CharacterController characterController;
    private float verticalSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() => walkAction.action.Enable();
    private void OnDisable() => walkAction.action.Disable();

    private void Start()
    {
        PlaySound(motoStop, 0.05f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (motoInfo.motoState == MotoStateEnum.Off)
        {
            PlaySound(motoStop, 0.05f);
            return;
        }

        Vector2 input = walkAction.action.ReadValue<Vector2>();

        if(input.sqrMagnitude > 0.01f)
        {
            PlaySound(motoRiding, 0.05f);
        }
        else
        {
            PlaySound(motoStop, 0.05f);
        }

        float turn = input.x * input.y * motoInfo.turnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, turn);

        Vector3 direction = transform.forward * input.y;
        Vector3 displacement = direction * motoInfo.speed;

        if (characterController.isGrounded && verticalSpeed < 0f)
            verticalSpeed = motoInfo.stayGroundForce;

        verticalSpeed += motoInfo.gravity * Time.deltaTime;
        displacement.y = verticalSpeed;

        characterController.Move(displacement * Time.deltaTime);
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        if (clip == audioSource.clip) return;

        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
