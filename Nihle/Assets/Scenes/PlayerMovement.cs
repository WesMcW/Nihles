using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float horizontalMovement = 0f;
    float verticalMovement = 0f;
    public bool isGrounded;
    
    //[SerializedField]
    float speed = 5f;
    float jumpSpeed = 20f;
    public float feetDist = 0.1f;

    public Vector2 movement;
    public Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //Vector3 playerMovement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f); 
        //Debug.Log(playerMovement);

        horizontalMovement = Input.GetAxisRaw("MoveHorizontal");
        //verticalMovement = Input.GetAxisRaw("MoveVertical");

        movement = new Vector2(horizontalMovement, verticalMovement);
        
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
        characterJump();
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed  * Time.deltaTime));

    }

    void characterJump()
    {
        if (isGrounded == true)
        {
            if (Input.GetButton("Jump"))
            {
                Debug.Log("Jumped");
                rb.MovePosition((Vector2)transform.position + (new Vector2(0f, 1f) * jumpSpeed * Time.deltaTime));
                isGrounded = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
            isGrounded = true;
    }
    
}
