using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    float speed = 5f;
    
    Vector2 mousePos;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Gets Input information from keypresses using WASD
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed",movement.sqrMagnitude);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        //This takes where your mouse is on the screen and then converts it to the unit system used by Unity with camera as a reference
       mousePos = Input.mousePosition;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        //This is a simple math equation that subtracts the position from your mouse to the player that gives you a vector that is pointing towards the mouse
       // Vector2 lookDirection = mousePos - rb.position;

    }
}
