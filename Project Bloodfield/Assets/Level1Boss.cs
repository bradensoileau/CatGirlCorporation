using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 1000;
    public Transform player; // Assign this to your player's transform in the inspector
    public GameObject projectilePrefab; // Assign this in the inspector
    public float attackRange = 1.0f; // Range for melee attack
    public float projectileSpeed = 10.0f; // Speed of the projectile
    private Animator animator; // Animator component
    private float rangeAttackInterval = 5.0f; // Interval for ranged attack

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(RangedAttackRoutine());
    }

    public void MeleeAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            animator.SetTrigger("MeleeAttack");
        }
    }

    IEnumerator RangedAttackRoutine()
    {
        while (true) // Infinite loop, will be managed by the coroutine system
        {
            yield return new WaitForSeconds(rangeAttackInterval);

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > attackRange)
            {
                RangeAttack();
            }
        }
    }

    public void RangeAttack()
    {
        // Play ranged attack animation if needed
        animator.SetTrigger("RangeAttack");

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Launch the projectile
        rb.velocity = direction * projectileSpeed;
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
    }
}
