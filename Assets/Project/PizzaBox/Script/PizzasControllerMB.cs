using System;
using TMPro;
using UnityEngine;

public class PizzasControllerMB : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private BoxInteracteMB boxInteracte;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI qtdPizzaUI;

    [Header("Deliverys")]
    [SerializeField] private GameObject firstDeliverys;
    [SerializeField] private GameObject secondDeliverys;

    [Header("Dungeon")]
    [SerializeField] private bool isDungeon;
    [SerializeField] private BoxCollider exitDoorCollider;

    [Header("Boss")]
    [SerializeField] private BossMB boss;

    private int pizzasRemaining = 3;
    private bool firstRound = true;

    public event Action allPizzasDelivered;

    private void OnEnable()
    {
        if (isDungeon) return;

        boxInteracte.pizzaTakedAction += TakedPizzas;
    }

    private void Start()
    {
        firstDeliverys.SetActive(true);

        if (isDungeon)
        {
            pizzasRemaining = 1;
            TakedPizzas();
        }

        if (secondDeliverys != null)
        {
            secondDeliverys.SetActive(false);
        }
    }

    private void TakedPizzas()
    {
        if (firstRound)
        {
            qtdPizzaUI.text = pizzasRemaining.ToString();
        }
        else
        {
            qtdPizzaUI.text = pizzasRemaining.ToString();
        }
    }

    public void DeliveredPizza()
    {
        pizzasRemaining -= 1;

        qtdPizzaUI.text = pizzasRemaining.ToString();


        if (pizzasRemaining == 0)
        {
            if (!isDungeon)
            {
                firstDeliverys.SetActive(false);
                secondDeliverys.SetActive(true);

                firstRound = false;
                pizzasRemaining = 1;

                allPizzasDelivered.Invoke();
            }
            else
            {
                exitDoorCollider.enabled = true;
            }
        }
    }
}
