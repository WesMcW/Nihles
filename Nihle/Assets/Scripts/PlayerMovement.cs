using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float horizontalMovement = 0f;
    float verticalMovement = 0f;
    public bool isGrounded;
    
    [SerializeField]
    float speed = 6.5f;
    [SerializeField]
    float jumpSpeed = 20f;
    

    public Vector2 movement;
    public Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //gets horizontal movement from controller
        horizontalMovement = Input.GetAxisRaw("MoveHorizontalOne");

        movement = new Vector2(horizontalMovement, verticalMovement);
        
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
        characterJump();
    }

    void moveCharacter(Vector2 direction)
    {
        
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
    }

    void characterJump()
    {
        if (isGrounded == true)
        {
            if (Input.GetButton("PlayerOneJump"))
            {
                Debug.Log("Jumped");
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpSpeed);
                isGrounded = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Ground")) 
            isGrounded = true;
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        //if player repeatedly presses jump they can remain unable to jump so this method is needed
        if (collision.CompareTag("Ground"))
            isGrounded = true;
    }
}
