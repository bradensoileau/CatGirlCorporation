using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradenStats : MonoBehaviour
{
    public float health = 70f;
    public float movementSpeed = 2;
    public float attackDamage = 20f;
    public float attackCooldown = 3f; // Cooldown time in seconds
    private float timeSinceLastAttack = 0f;
    private Animator animator;
    public GameObject player; // Assign this in the inspector with your player GameObject
    private Transform targetTransform; // Transform of the target (player)
    //public GameObject floatingTextPrefab;
    // public ScoreBoard scoreBoard;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (player != null)
        {
            targetTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned!");
        }
    }

    private void Update()
    {
        if (timeSinceLastAttack < attackCooldown)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if (targetTransform != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && timeSinceLastAttack >= attackCooldown)
        {
            Attack();
        }
    }

    private void MoveTowardsPlayer()
    {
        //Moves to player
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        transform.position += direction * movementSpeed * Time.deltaTime;
        //plays walk animation
        Walk();
    }



    public void Attack()
    {
        if (timeSinceLastAttack >= attackCooldown)
        {
            StopWalking();
            animator.SetTrigger("Attack"); // Trigger the attack animation
            timeSinceLastAttack = 0f; // Reset the cooldown timer
            ApplyDamage();
        }
    }

    private void ApplyDamage()
    {
        if (player != null)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(attackDamage);
            }
        }
    }

    private void PlayDamageAnimation()
    {
        animator.SetTrigger("TakeDamage"); // Assuming you have a trigger named "TakeDamage" in your Animator
    }

    public void Walk()
    {
        animator.SetBool("IsWalking", true); // Assuming you have a boolean parameter named "IsWalking" in your Animator
    }

    public void StopWalking()
    {
        animator.SetBool("IsWalking", false);
    }

    private void Die()
    {
        //scoreBoard.IncrementScore();
        gameObject.SetActive(false); // Or Destroy(gameObject); based on your preference
    }

    private void ShowFloatingText(float damageAmount)
    {
        // Implement floating text logic
    }

    private void UpdateHealthUI()
    {
        // Update UI logic
    }

}
