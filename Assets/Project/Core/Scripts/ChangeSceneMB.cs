using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMB : MonoBehaviour, IInteractable
{
    [Header("Scene")]
    [SerializeField] private string sceneName;

    [Header("Description")]
    [SerializeField] private string prompt;

    [Header("Player")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private PlayerInfoSO playerInfo;

    public bool isDungeon;

    public string Prompt
    {
        get { return prompt; }
        set { prompt = value; }
    }

    public bool canInteract => true;

    public void Interact()
    {
        playerInfo.speed = playerSpeed;

        if (!isDungeon)
        {
            SceneStateControllerMB.Instance.sceneState = SceneState.inDungeon;
        }
        else
        {
            SceneStateControllerMB.Instance.sceneState = SceneState.exitDungeon;
        }

        SceneManager.LoadScene(sceneName);
    }
}
