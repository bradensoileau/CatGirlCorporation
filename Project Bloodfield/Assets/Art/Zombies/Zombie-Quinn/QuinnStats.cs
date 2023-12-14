using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuinnStats : MonoBehaviour
{
    public float health = 70f;
    public float rangedAttackCooldown = 2f; // Cooldown time for ranged attack in seconds
    public GameObject slimeBallPrefab; // Assign this in the inspector with your slime ball projectile GameObject
    public float detectionRange = 40f; // Detection range in unit
    private float timeSinceLastRangedAttack = 0f;
    private Animator animator;
    public GameObject player; // Assign this in the inspector with your player GameObject
    private Transform targetTransform;
    public GameObject floatingTextPrefab;
    public ScoreBoard scoreBoard; // If you need a ScoreBoard reference

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
        if (timeSinceLastRangedAttack < rangedAttackCooldown)
        {
            timeSinceLastRangedAttack += Time.deltaTime;
        }

        if (targetTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, targetTransform.position);

            // Check if the player is within the detection range
            if (distanceToPlayer <= detectionRange)
            {
                RangedAttack();
            }
        }
    }

    public void RangedAttack()
    {
        if (timeSinceLastRangedAttack >= rangedAttackCooldown)
        {
            animator.SetTrigger("RangedAttack"); // Trigger the ranged attack animation
            timeSinceLastRangedAttack = 0f; // Reset the ranged attack cooldown timer

            // Instantiate the slime ball projectile and shoot it towards the player
            if (slimeBallPrefab != null)
            {
                GameObject slimeBall = Instantiate(slimeBallPrefab, transform.position, Quaternion.identity);
                SlimeBall slimeBallScript = slimeBall.GetComponent<SlimeBall>();

                // Check if the script exists on the projectile
                if (slimeBallScript != null)
                {
                    slimeBallScript.Launch(targetTransform.position);
                }
                else
                {
                    Debug.LogError("SlimeBall script not found on the slimeBallPrefab!");
                }
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

    public void StopWalking()
    {
        animator.SetBool("IsWalking", false);
    }

    private void Die()
    {
        scoreBoard.AddScore(3);
        Destroy(gameObject);
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
