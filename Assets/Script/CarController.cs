using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Enum to define car types: Player-controlled or AI-controlled cop
public enum cartype { player, cop }

public class CarController : MonoBehaviour
{
    // Rigidbody component for physics interactions
    public Rigidbody rb;
    
    // Reference to the car's visual model
    public GameObject carbody;
    
    // Movement parameters
    public float forwardSpeed = 5f;  // Acceleration speed
    public float maxSpeed = 30f;     // Maximum movement speed
    public float turnSpeed = 10f;    // Rotation speed

    // Player input values
    private float vertical;
    private float horizontal;

    // Ground detection
    public LayerMask whatIsGround;   // Defines which layers count as ground
    public float groundRayLength = 0.5f;  // Length of the ground detection ray
    public Transform groundRayPoint; // Origin point for ground detection ray
    public bool grounded;            // Whether the car is currently on the ground

    // UI display for speed
    public TMP_Text speedtext;

    // Audio sources for collision sounds
    public AudioSource audioPlayer;  // Sound for AI car collision
    public AudioSource audioPlayer1; // Sound for environment collision

    // Determines if the car is player-controlled or an AI cop
    public cartype ct;

    private void Update()
    {
        // Handle player input only if the car is the player-controlled vehicle
        if (ct == cartype.player)
        {
            vertical = Input.GetAxis("Vertical");   // Forward and backward movement
            horizontal = Input.GetAxis("Horizontal"); // Steering left and right
        }

        // Rotate the car based on input
        RotateCar();

        // Update the speed display
        UpdateUI();
    }

    // Function to receive AI input (used for cop car behavior)
    public void GetAIInput(float verticalInput, float horizontalInput)
    {
        vertical = verticalInput;
        horizontal = horizontalInput;
    }

    private void LateUpdate()
    {
        // Ensures the car's visual model follows the physics object
        carbody.transform.position = this.transform.position + new Vector3(0, -0.5f, 0);
        carbody.transform.rotation = this.transform.rotation;
    }

    // Handles car rotation based on input
    public void RotateCar()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, horizontal * turnSpeed * Time.deltaTime, 0));
    }

    private void FixedUpdate()
    {
        grounded = false; // Reset ground check

        // Perform a raycast downward to check if the car is on the ground
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            // Adjust car rotation to match the surface normal (useful for slopes)
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        // Apply movement force only if the car is on the ground
        if (grounded)
        {
            if (rb.velocity.magnitude < maxSpeed) // Ensure the speed does not exceed the limit
            {
                rb.AddForce(transform.forward * vertical * forwardSpeed); // Apply forward movement
            }
        }
    }

    // Updates the speedometer UI with the current speed
    public void UpdateUI()
    {
        speedtext.text = Mathf.FloorToInt(rb.velocity.magnitude * 3.6f) + " kph"; // Convert speed to km/h
    }

    // Trigger event for detecting collisions with environment objects
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollisionTag")
        {
            audioPlayer1.Play(); // Play collision sound
        }
    }

    // Collision event for detecting impacts with AI police cars
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PCar")
        {
            audioPlayer.Play(); // Play police car collision sound
        }
    }
}
