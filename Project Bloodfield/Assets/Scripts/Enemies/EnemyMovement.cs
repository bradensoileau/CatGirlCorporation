using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject player;
    public float speed = 3f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;

            rb.velocity = direction * speed;
            
            if (rb.velocity.x > 0)
            {
                spriteRenderer.flipX = false; //NOT FLIPPED
            }
            else if (rb.velocity.x < 0)
            {
                spriteRenderer.flipX = true; //FLIPPED
            }

        }
    }
}
