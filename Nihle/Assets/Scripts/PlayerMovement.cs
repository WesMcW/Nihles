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

    [SerializeField]
    public float lowJumpMultiplier = 2f;
    public float fallMultiplier = 2.5f;

    public Vector2 movement;
    public Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Debug.Log(Input.GetJoystickNames()[0]);
        //gets horizontal movement from controller
        if (Input.GetJoystickNames().Length > 0)
        {
            if (Input.GetJoystickNames()[0].Length == 33 || Input.GetJoystickNames()[0].Length == 19 || Input.GetJoystickNames()[0].Length == 25) horizontalMovement = Input.GetAxisRaw("MoveHorizontalOne");
            else horizontalMovement = Input.GetAxisRaw("PlayerOneKeyMove");
        }
        else horizontalMovement = Input.GetAxisRaw("PlayerOneKeyMove");
        movement = new Vector2(horizontalMovement, verticalMovement);

        anim.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        anim.SetFloat("VertSpeed", rb.velocity.y);
        anim.SetBool("onGround", isGrounded);
    }

    void FixedUpdate()
    {

        moveCharacter(movement);
        characterJump();
        gravity();
    }

    void moveCharacter(Vector2 direction)
    {
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);

        //flips character sprite based on movement
        Vector3 playerScale = transform.localScale;
        if(horizontalMovement < 0)
        {
            playerScale.x = -1;
        } else if (horizontalMovement > 0)
        {
            playerScale.x = 1;
        }

        transform.localScale = playerScale;
    }

    void characterJump()
    {
        if (isGrounded == true)
        {
            if (Input.GetButton("PlayerOneJump"))
            {
                Debug.Log("Jumped");
                rb.velocity = Vector2.up * jumpSpeed;
                isGrounded = false;
            }
        }    
    }

    void gravity()
    {
        if (rb.velocity.y < 0)                                                                              //if button is held
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetButton("PlayerOneJump"))                                    //essentially the short hop
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Ground") || collision.CompareTag("PushBlock")) 
            if(rb.velocity.y <= 0) isGrounded = true;
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        //if player repeatedly presses jump they can remain unable to jump so this method is needed
        if (collision.CompareTag("Ground") || collision.CompareTag("PushBlock"))
            if (rb.velocity.y <= 0) isGrounded = true;
    }

    public void disableThings()
    {
        rb.velocity = Vector2.zero;
        anim.SetBool("onGround", true);
        anim.SetFloat("Speed", 0);

        this.enabled = false;
    }
}
