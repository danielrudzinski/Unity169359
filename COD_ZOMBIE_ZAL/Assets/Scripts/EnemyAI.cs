using UnityEngine;
using UnityEngine.AI; 

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
        
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}