using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradenStats : MonoBehaviour
{
    public float health = 70f;
    public float attackDamage = 20f;
    public float attackCooldown = 3f; // Cooldown time in seconds
    private float timeSinceLastAttack = 0f;
    private Animator animator;
    public GameObject player; // Assign this in the inspector with your player GameObject
    private Transform targetTransform; // Transform of the target (player)
    public GameObject floatingTextPrefab;
    private ScoreBoard scoreBoard; // If you need a ScoreBoard reference

    private void Start()
    {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && timeSinceLastAttack >= attackCooldown)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (timeSinceLastAttack >= attackCooldown)
        {
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

    public void TakeDamage(float damageAmount)
    {
        if (health > 0)
        {
            if (floatingTextPrefab)
            {
                ShowFloatingText(damageAmount);
            }

            health -= damageAmount;

            if (health <= 0)
            {
                Die();
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

    private void Die()
    {
        scoreBoard.AddScore(1);
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
