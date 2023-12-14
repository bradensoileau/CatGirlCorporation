using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject iceProjectilePrefab; // Assign your ice shard prefab in the Inspector
    public GameObject wandPosition; // Assign your Wand GameObject in the Inspector

    void Update()
    {

        if (Camera.main == null) return;
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure the Z-coordinate matches your game's plane.

            LaunchIceProjectile(mousePos);
        }
    }

    void LaunchIceProjectile(Vector2 target)
    {
        if (iceProjectilePrefab == null)
        {
            Debug.LogError("Ice projectile prefab is not assigned!");
            return;
        }

        // Instantiate the ice projectile at the wand's position.
        GameObject iceProjectile = Instantiate(iceProjectilePrefab, wandPosition.transform.position, Quaternion.identity);
        IceProjectile iceScript = iceProjectile.GetComponent<IceProjectile>();

        // Check if iceScript is not null before calling Launch.
        if (iceScript != null)
        {
            iceScript.Launch(target);
        }
    }
}

