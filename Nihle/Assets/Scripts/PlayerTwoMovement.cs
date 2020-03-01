using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
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
        //gets horizontal movement from controller
        if (Input.GetJoystickNames()[1].Length == 33 || Input.GetJoystickNames()[1].Length == 19) horizontalMovement = Input.GetAxisRaw("MoveHorizontalTwo");
        else horizontalMovement = Input.GetAxisRaw("PlayerTwoKeyMove");

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
        if (horizontalMovement < 0)
        {
            playerScale.x = -1;
        }
        else if (horizontalMovement > 0)
        {
            playerScale.x = 1;
        }

        transform.localScale = playerScale;
    }

    void characterJump()
    {
        if (isGrounded == true)
        {
            if (Input.GetButton("PlayerTwoJump"))
            {
                Debug.Log("Jumped");
                //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpSpeed);
                rb.velocity = Vector2.up * jumpSpeed;
                isGrounded = false;
            }
        }
    }

    void gravity()
    {
        if (rb.velocity.y < 0)                                                                              //if button is held
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetButton("PlayerTwoJump"))                                    //essentially the short hop
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //if player repeatedly presses jump they can remain unable to jump so this method is needed
        if (collision.CompareTag("Ground"))
            isGrounded = true;
    }

    public void disableThings()
    {
        rb.velocity = Vector2.zero;
        anim.SetBool("onGround", true);
        anim.SetFloat("Speed", 0);

        this.enabled = false;
    }
}
