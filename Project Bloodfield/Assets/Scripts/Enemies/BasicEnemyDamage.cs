using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradenCharacter : MonoBehaviour
{
    private Animator animator;
    public int damageAmount = 10;
    public string playerTag = "Player";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        animator.SetTrigger("Attack"); // Trigger the attack animation
    }

    public void PlayDamageAnimation()
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Attack();
            }
        }
    }
}
