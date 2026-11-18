using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerMB : MonoBehaviour
{
    [Header("SpawnPoints")]
    [SerializeField] private Transform startGamePlayer;
    [SerializeField] private Transform startGameMoto;
    [SerializeField] private Transform dungeonExitPlayer;
    [SerializeField] private Transform dungeonExitMoto;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject moto;

    [Header("Walls")]
    [SerializeField] private GameObject wall;

    [Header("Boss")]
    [SerializeField] private BossMB boss;

    [Header("Set Inactive")]
    [SerializeField] private GameObject audio1;
    [SerializeField] private GameObject audio2;
    [SerializeField] private GameObject Block;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneStateControllerMB.Instance.sceneState == SceneState.inCity)
        {
            player.transform.position = startGamePlayer.position;
            moto.transform.position = startGameMoto.position;
        }
        else if (SceneStateControllerMB.Instance.sceneState == SceneState.exitDungeon)
        {
            player.transform.position = dungeonExitPlayer.position;
            moto.transform.position= dungeonExitMoto.position;

            wall.SetActive(false);

            boss.EndGame();

            audio1.SetActive(false);
            audio2.SetActive(false);
            Block.SetActive(false);
        }
    }
}
