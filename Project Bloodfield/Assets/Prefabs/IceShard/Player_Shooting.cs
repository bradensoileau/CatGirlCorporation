using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject iceProjectilePrefab; // Assign your ice shard prefab in the Inspector
    public GameObject fireBoltPrefab; // Assign your fire bolt prefab in the Inspector

    void Update()
    {
        if (Camera.main == null) return;

        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure the Z-coordinate matches your game's plane.

            LaunchIceProjectile(mousePos);
        }

        if (Input.GetMouseButtonDown(1)) // Check for right mouse button click
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure the Z-coordinate matches your game's plane.

            LaunchFireBolt(mousePos);
        }
    }

    void LaunchIceProjectile(Vector2 target)
    {
        GameObject iceProjectile = Instantiate(iceProjectilePrefab, transform.position, Quaternion.identity);
        IceProjectile iceScript = iceProjectile.GetComponent<IceProjectile>();

        if (iceProjectilePrefab == null)
        {
            Debug.LogError("Ice projectile prefab is not assigned!");
            return;
        }

        // Safety measure to prevent calling a null iceScript if it does not exist
        if (iceScript != null)
        {
            iceScript.Launch(target);
        }
    }

    void LaunchFireBolt(Vector2 target)
    {
        GameObject fireBolt = Instantiate(fireBoltPrefab, transform.position, Quaternion.identity);
        FireBolt fireBoltScript = fireBolt.GetComponent<FireBolt>();

        if (fireBoltPrefab == null)
        {
            Debug.LogError("Fire bolt prefab is not assigned!");
            return;
        }

        // Safety measure to prevent calling a null fireBoltScript if it does not exist
        if (fireBoltScript != null)
        {
            fireBoltScript.Launch(target);
        }
    }


}
