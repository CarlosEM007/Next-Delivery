using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractMB : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference interactAction;

    [Header("Reference")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private PlayerHandMB playerHand;

    [Header("Player Info")]
    [SerializeField] private PlayerInfoSO playerInfo;

    private IInteractable currentTarget;

    public event Action<IInteractable> targetChanged;

    private void OnEnable()
    {
        interactAction.action.Enable();
        interactAction.action.performed += Interect;
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
        interactAction.action.performed -= Interect;
    }

    private void Update()
    {
        // Prioridade para o que está na mira (ex.: a porta); se não tiver nada útil, usa o item da mão
        IInteractable newTarget = SearchTarget();

        if (playerHand.IsOccupied && (newTarget == null || !newTarget.canInteract))
            newTarget = playerHand.GetInteractable();

        if (newTarget == currentTarget)
            return;

        currentTarget = newTarget;
        targetChanged?.Invoke(currentTarget);
    }

    private IInteractable SearchTarget()
    {
        Vector3 origen = playerCamera.position;
        Vector3 direction = playerCamera.forward;

        Debug.DrawLine(origen, direction * playerInfo.interactDistance, Color.red);

        if (!Physics.Raycast(origen, direction, out RaycastHit hit, playerInfo.interactDistance,
                            playerInfo.mask, QueryTriggerInteraction.Ignore))
        {
            return null;
        }

        return hit.collider.GetComponentInParent<IInteractable>();
    }

    private void Interect(InputAction.CallbackContext context)
    {
        if (!AlvoValido() || !currentTarget.canInteract)
            return;

        if (playerHand.IsOccupied && currentTarget == playerHand.GetInteractable())
        {
            playerHand.UseHeldItem();
            return;
        }

        currentTarget.Interact();
    }

    private bool AlvoValido() => currentTarget is UnityEngine.Object obj && obj != null;
}
