using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - firePoint.position).normalized; // Calculate the direction to the mouse.

        // Create a bullet at the firePoint's position.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Move the bullet using the Transform in the direction calculated.
        bullet.transform.Translate(direction * bulletForce, Space.World);

        Destroy(bullet, 5.0f);
    }
}
