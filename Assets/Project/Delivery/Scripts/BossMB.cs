using System.Collections;
using UnityEngine;

public class BossMB : MonoBehaviour, IInteractable
{
    [Header("Pizza Controller")]
    [SerializeField] private PizzasControllerMB pizzaController;
    [SerializeField] private BoxInteracteMB boxInteracte;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip firstDelivery;
    [SerializeField] private AudioClip inDelivery;
    [SerializeField] private AudioClip endFirst;
    [SerializeField] private AudioClip rockSong;
    [SerializeField] private AudioClip whereDidyouGo;
    [SerializeField] private AudioClip explanation;
    [SerializeField] private AudioClip itsALie;

    [Header("Player")]
    [SerializeField] private PlayerMoveMB playerMove;

    [Header("Invisible Wall")]
    [SerializeField] private GameObject invisibleWall;

    [Header("Credits")]
    [SerializeField] private GameObject credits;

    private string prompt = "Talk with Boss";
    private BossStateEnum bossState;

    public string Prompt
    {
        get { return prompt; }
        set { prompt = value; }
    }

    public bool canInteract => true;

    private void Awake()
    {
        pizzaController.allPizzasDelivered += AllPizzaDelivered;
    }

    public void Interact()
    {
        switch (bossState)
        {
            case BossStateEnum.firstDelivery:
                AudioManagerMB.Instance.PlaySFX(firstDelivery, 0.5f);

                StartCoroutine(playerMove.StopPlayer(firstDelivery.length));

                boxInteracte.ChangeVisibility();
                bossState = BossStateEnum.inFirst;

                invisibleWall.SetActive(false);

                AudioManagerMB.Instance.PlayMusic(rockSong, 0.1f);
                break;
            case BossStateEnum.inFirst:
                AudioManagerMB.Instance.PlaySFX(inDelivery, 0.5f);

                StartCoroutine(playerMove.StopPlayer(inDelivery.length));

                break;
            case BossStateEnum.endFirst:
                AudioManagerMB.Instance.PlaySFX(endFirst, 0.5f);

                StartCoroutine(playerMove.StopPlayer(endFirst.length));

                boxInteracte.ChangeVisibility();
                bossState = BossStateEnum.inFirst;
                break;
            case BossStateEnum.endSecond:

                StartCoroutine(FinalDialogue());
                StartCoroutine(playerMove.StopPlayer(whereDidyouGo.length + explanation.length + itsALie.length));

                break;
        }
    }

    private void AllPizzaDelivered()
    {
        bossState = BossStateEnum.endFirst;
    }

    public void EndGame()
    {
        bossState = BossStateEnum.endSecond;
    }

    private IEnumerator FinalDialogue()
    {
        AudioManagerMB.Instance.PlaySFX(whereDidyouGo, 0.5f);
        yield return new WaitForSeconds(whereDidyouGo.length);

        AudioManagerMB.Instance.PlaySFX(explanation, 0.5f);
        yield return new WaitForSeconds(explanation.length);

        AudioManagerMB.Instance.PlaySFX(itsALie, 0.5f);
        yield return new WaitForSeconds(itsALie.length);

        credits.SetActive(true);
    }
}
