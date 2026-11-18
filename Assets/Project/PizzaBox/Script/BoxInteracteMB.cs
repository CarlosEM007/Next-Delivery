using System;
using UnityEngine;

public class BoxInteracteMB : MonoBehaviour, IInteractable
{
    private string prompt = "Take Pizzas!";

    public event Action pizzaTakedAction;

    public string Prompt
    {
        get { return prompt; }
        set { prompt = value; }
    }

    public bool canInteract => true;

    public void Interact()
    {
        pizzaTakedAction?.Invoke();
        gameObject.SetActive(false);
    }

    public void ChangeVisibility()
    {
        gameObject.SetActive(true);
    }
}
