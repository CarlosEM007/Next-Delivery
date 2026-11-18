using System;
using System.Collections;
using UnityEngine;

public class EquipGunMB : MonoBehaviour, IInteractable
{
    [Header("Audio Clip")]
    [SerializeField] private AudioClip gunTakedClip;

    [Header("Reference")]
    [SerializeField] private GameObject block;

    public event Action gunEquipedEvent;

    private string prompt = "Take the gun!";

    public string Prompt
    {
        get { return prompt; }
        set { prompt = value; }
    }

    public bool canInteract => true;

    public void Interact()
    {
        gunEquipedEvent?.Invoke();

        AudioManagerMB.Instance.PlaySFX(gunTakedClip);


        if (block != null) Destroy(block);

        Destroy(gameObject);
    }
}
