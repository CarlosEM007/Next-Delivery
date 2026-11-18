using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsChangeMB : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private RawImage image;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;

    [Header("Player")]
    [SerializeField] private PlayerMoveMB playerMove;

    [Header("Sprites")]
    [SerializeField] private Texture GameJam;
    [SerializeField] private Texture Monkey;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip switchSlide;

    private void Start()
    {
        SetPlayerControls();
        StartCoroutine(StartSlides());
    }

    private IEnumerator StartSlides()
    {
        AudioManagerMB.Instance.PlaySFX(switchSlide);

        image.texture = Monkey;
        title.text = "Game By";
        description.text = "Carlos E. Menegassi";

        yield return new WaitForSeconds(3);

        AudioManagerMB.Instance.PlaySFX(switchSlide);

        image.texture = GameJam;
        title.text = "Made in five days For";
        description.text = "The Creative Forge: Vol. 1";

        yield return new WaitForSeconds(3);

        AudioManagerMB.Instance.PlaySFX(switchSlide);

        image.gameObject.SetActive(false);
        title.text = "Thank You for Playing!";
        description.text = "";

        yield return new WaitForSeconds(3);

        AudioManagerMB.Instance.StopMusic();
        SceneManager.LoadScene("Menu");
    }

    private void SetPlayerControls()
    {
        playerMove.StopPlayer(100);
    }
}
