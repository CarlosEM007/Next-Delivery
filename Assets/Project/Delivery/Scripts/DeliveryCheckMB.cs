using UnityEngine;

public class DeliveryCheckMB : MonoBehaviour, IInteractable
{
    [Header("Events")]
    [SerializeField] private BoxInteracteMB boxInterateAction;

    [Header("Reference")]
    [SerializeField] private GameObject arrow;
    [SerializeField] private PizzasControllerMB controller;

    [Header("Dungeon")]
    [SerializeField] private bool isDungeon;

    private string prompt = "Deliver";

    public string Prompt
    {
        get { return prompt; }
        set { prompt = value; }
    }

    public bool canInteract => arrow.activeSelf;

    void OnEnable()
    {
        if (isDungeon)
        {
            StartDelivery();
            return;
        }

        boxInterateAction.pizzaTakedAction += StartDelivery;
    }

    public void Interact()
    {
        controller.DeliveredPizza();
        arrow.SetActive(false);

        prompt = "...";
    }

    public void StartDelivery()
    {
        arrow.SetActive(true);
    }
}
