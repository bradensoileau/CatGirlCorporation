using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 1000;
    public Transform player; // Assign this to your player's transform in the inspector
    public GameObject gigaLaserPrefab; // Assign your Giga Laser prefab here in the inspector
    private Animator animator; // Animator component
    private float rangeAttackInterval = 5.0f; // Interval for Giga Laser attack
    private float initialDelay = 12.0f; // Initial delay before the first laser attack

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(RangedAttackRoutine());
    }

    IEnumerator RangedAttackRoutine()
    {
        // Wait for the initial delay before the first attack
        yield return new WaitForSeconds(initialDelay);

        while (true) // Infinite loop, will be managed by the coroutine system
        {
            GigaLaserAttack();

            // Wait for the interval before the next attack
            yield return new WaitForSeconds(rangeAttackInterval);
        }
    }

    public void GigaLaserAttack()
    {
        // Play ranged attack animation if needed
        animator.SetTrigger("RangeAttack");

        // Calculate the offset position for spawning the Giga Laser
        Vector3 spawnOffset = new Vector3(0, 0, 1); // Adjust this to match the boss's mouth position
        Vector3 spawnPosition = transform.position + transform.rotation * spawnOffset;

        // Instantiate the Giga Laser at the offset position
        GameObject laserInstance = Instantiate(gigaLaserPrefab, spawnPosition, Quaternion.identity);

        // Launch the Giga Laser towards the player
        GigaLaserProjectile gigaLaserProjectile = laserInstance.GetComponent<GigaLaserProjectile>();
        if (gigaLaserProjectile != null)
        {
            gigaLaserProjectile.Launch(player.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StopAllCoroutines();
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss is defeated!");
        // Additional logic for boss death (e.g., animations, game state changes) can be added here.
    }
}
