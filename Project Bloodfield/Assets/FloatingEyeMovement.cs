using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEyeMovement : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float moveSpeed = 3.0f; // Enemy movement speed
    public float followRadius = 5.0f; // Radius around the player
    private bool movingRight = true; // Flag to determine the movement direction
    private Vector3 initialPosition; // Initial position of the enemy
    private float elapsedTime = 0.0f;

    void Start()
    {
        // Store the initial position of the enemy
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance between the enemy and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);


            // Calculate the direction towards the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            if (movingRight)
            {
                // Move to the right
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Move to the left
                transform.Translate(-direction * moveSpeed * Time.deltaTime);
            }

            // Check if the enemy should change direction
            if (elapsedTime >= 2.0f)
            {
                movingRight = !movingRight;
                elapsedTime = 0.0f;
            }

            elapsedTime += Time.deltaTime;
        }
    }
}
