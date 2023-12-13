using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject iceProjectilePrefab; // Assign your ice shard prefab in the Inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure the Z-coordinate matches your game's plane.

            LaunchIceProjectile(mousePos);
        }
    }

    void LaunchIceProjectile(Vector2 target)
    {
        GameObject iceProjectile = Instantiate(iceProjectilePrefab, transform.position, Quaternion.identity);
        IceProjectile iceScript = iceProjectile.GetComponent<IceProjectile>();
        
        //safty measure in order to prevent calling a null iceScript if it does not exist
        if (iceScript != null)
        {
            iceScript.Launch(target);
        }
    }
}

