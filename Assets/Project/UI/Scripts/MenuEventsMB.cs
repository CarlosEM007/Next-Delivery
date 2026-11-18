using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEventsMB : MonoBehaviour
{
    [Header("AudioClip")]
    [SerializeField] private AudioClip audio;
    [SerializeField] private AudioClip music;

    private void Start()
    {
        AudioManagerMB.Instance.PlayMusic(music, 0.3f);
    }

    public void PlaySFX()
    {
        AudioManagerMB.Instance.PlaySFX(audio);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("City");
    }
}
