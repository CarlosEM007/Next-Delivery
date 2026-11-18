using System;
using System.Collections;
using UnityEngine;

public class EquipGunMB : MonoBehaviour, IInteractable
{
    [Header("Audio Clip")]
    [SerializeField] private AudioClip gunTakedClip;

    public event Action gunTaked;

    private string prompt = "Take the gun!";

    public string Prompt
    {
        get { return prompt; }
        set { prompt = value; }
    }

    public bool canInteract => true;

    public void Interact()
    {
        gunTaked.Invoke();

        StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound()
    {
        AudioManagerMB.Instance.PlaySFX(gunTakedClip);

        yield return new WaitForSeconds(gunTakedClip.length);

        Destroy(gameObject);
    }
}
