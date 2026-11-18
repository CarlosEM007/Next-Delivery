using UnityEngine;

public class PlayASoundHereMB : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject gameObjectToInvisible;
    [SerializeField] private GameObject[] gameObjectToVisible;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip audioClip;

    [Header("Configuration")]
    [SerializeField] private bool ChangeMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Moto"))
        {
            if (!ChangeMusic)
            {
                AudioManagerMB.Instance.PlaySFX(audioClip, 0.5f);
            }
            else
            {
                AudioManagerMB.Instance.PlayMusic(audioClip, 0.1f);
            }

            if(gameObjectToInvisible != null)
            {
                gameObjectToInvisible.SetActive(false);
            }

            if(gameObjectToVisible != null)
            {
                for(int i = 0; i <  gameObjectToVisible.Length; i++)
                {
                    gameObjectToVisible[i].SetActive(true);
                }
            }

            Destroy(gameObject);
        }
    }
}
