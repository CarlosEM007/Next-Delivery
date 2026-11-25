using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseMB : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
