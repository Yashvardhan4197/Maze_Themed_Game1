using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    [SerializeField] PlayerDeathHandler playerDeathHandler;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            // Find the player GameObject using a tag or other means
            player = GameObject.FindGameObjectWithTag("Player").transform;

            if (player == null)
            {
                Debug.LogError("Player not found. Make sure to tag the player GameObject with 'Player' tag.");
            }
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Set the destination to the player's position
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the enemy collides with the player
        if (other.tag=="Player")
        {
            // Call a method to handle player death
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        // You can implement logic here to handle player death.
        // For example, restart the level, show a game over screen, etc.
        Debug.Log("Player Died!");
        playerDeathHandler.reduceHealth();
    }
}
