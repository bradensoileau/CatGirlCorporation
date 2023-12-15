using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSkull : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public GameObject laserPrefab; // Reference to the laser prefab
    public float moveSpeed = 3.0f; // Enemy movement speed
    public float fireRate = 1.0f; // Rate at which lasers are fired
    public float followRadius = 5.0f; // Radius around the player
    private bool movingRight = true; // Flag to determine the movement direction
    private Vector3 initialPosition; // Initial position of the enemy
    private float elapsedTime = 0.0f;
    private float fireElapsedTime = 0.0f; // Timer to track laser firing

    void Start()
    {
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            Vector3 direction = (player.transform.position - transform.position).normalized;

            if (movingRight)
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-direction * moveSpeed * Time.deltaTime);
            }

            if (elapsedTime >= 2.0f)
            {
                movingRight = !movingRight;
                elapsedTime = 0.0f;
            }

            elapsedTime += Time.deltaTime;

            // Laser firing logic
            if (fireElapsedTime >= fireRate)
            {
                FireLasers();
                fireElapsedTime = 0.0f;
            }

            fireElapsedTime += Time.deltaTime;
        }
    }

    void FireLasers()
    {
        // Fire three lasers in different directions
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
        Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, 45));
        Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, -45));
    }
}
