using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    void Update()
    {
        // Check for mouse input (left mouse button) to shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Make sure it's in the same Z-plane as the 2D world

        // Calculate the direction from the player to the mouse cursor
        Vector3 direction = (mousePosition - firePoint.position).normalized;

        // Create a bullet instance
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Access the Rigidbody2D of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply a force to the bullet to make it move in the direction of the mouse cursor
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

        //deystroys the bullet after a certain amount of time
        Destroy(bullet, 5.0f);
    }
}
