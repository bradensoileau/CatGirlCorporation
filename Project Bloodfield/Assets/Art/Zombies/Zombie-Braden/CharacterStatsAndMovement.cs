using UnityEngine;
using Unity.VisualScripting;

public class CharacterStatsAndMovement : MonoBehaviour
{
    // Health and Damage Variables
    public float health = 50f;
    public GameObject floatingTextPrefab;
    public ScoreBoard scoreBoard;
    public bool isAttacking;

    private Animator animator;
    public int damageAmount = 10;
    public string playerTag = "Player";
    public float attackRadius = 1.0f; // Radius within which to start melee attack

    // Movement Variables
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public GameObject player;
    public float moveSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
        player = GameObject.FindGameObjectWithTag("Player");

        rb.isKinematic = true; // Make Rigidbody2D not react to physics forces
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= attackRadius)
            {
                Attack();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        bool isMoving = rb.velocity.magnitude > 0;
        animator.SetBool("IsWalking", isMoving);

        spriteRenderer.flipX = rb.velocity.x < 0; // Flip sprite based on direction
    }

    public void TakeDamage(float damageAmount)
    {
        if (floatingTextPrefab && health > 0)
        {
            ShowFloatingText(damageAmount);
        }

        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (scoreBoard != null)
        {
            scoreBoard.AddScore(1);
        }
        Destroy(gameObject);
    }

    void ShowFloatingText(float damageAmount)
    {
        var spawnText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        spawnText.GetComponent<TextMesh>().text = damageAmount.ToString();
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

        // Check if player is within attack range
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRadius)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damageAmount);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            PlayerStats targetHealth = collision.gameObject.GetComponent<PlayerStats>();

            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damageAmount);
            }
        }
    }
}
