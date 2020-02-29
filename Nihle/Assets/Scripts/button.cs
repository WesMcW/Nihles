using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject platform;
    public Animator animator;
    public bool isPlatformButton;
    public bool isWorldChangeButton;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")){
            collision.gameObject.transform.parent = gameObject.transform;
            animator.SetBool("isPressed", true);
            if(isPlatformButton == true) {
                platform.SetActive(true);
            }
            if(isWorldChangeButton == true) {

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")){
            animator.SetBool("isPressed", false);
            collision.gameObject.transform.parent = null;
        }
    }
}
