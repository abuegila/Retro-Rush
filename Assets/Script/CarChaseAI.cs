using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI Car Chase Behavior
public class CarChaseAI : MonoBehaviour
{
    // Reference to the target (player) the AI will chase
    public Transform target;

    // Reference to the AI car's movement controller
    public CarController carController;

    // The minimum distance before the AI starts chasing the player
    public float chaseDistance = 2f;

    private void Awake()
    {
        // Get the CarController component attached to this GameObject
        carController = GetComponent<CarController>();
    }

    private void Update()
    {
        // Calculate the distance between the AI car and the target (player)
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // If the target is beyond the chase distance, initiate pursuit
        if (distanceToTarget > chaseDistance)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        // Calculate the direction vector from the AI car to the player
        Vector3 directionToPlayer = (target.position - transform.position).normalized;

        // Determine if the player is to the left or right of the AI car
        float dotProduct = Vector3.Dot(transform.right, directionToPlayer);

        // Set horizontal input: positive if player is to the right, negative if to the left
        float horizontalInput = (dotProduct > 0) ? 1f : -1f;

        // Determine forward input based on alignment with player's direction
        float verticalInput = Mathf.Clamp01(Vector3.Dot(transform.forward, directionToPlayer));

        // Send the calculated input values to the AI car's movement system
        carController.GetAIInput(verticalInput, horizontalInput);
    }
}
