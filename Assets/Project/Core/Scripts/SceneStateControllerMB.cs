using UnityEngine;

public class SceneStateControllerMB : MonoBehaviour
{
    public SceneState sceneState;

    public static SceneStateControllerMB Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
