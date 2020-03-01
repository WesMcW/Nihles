using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mover;

public class button : MonoBehaviour
{

    public LayerMask pushBlocky;
    public GameObject platform;
    public Animator animator;
    public Sprite active, inactive;
    public bool isPlatformButton;
    public bool isWorldChangeButton;
    public bool isDisappearing = false;
    bool playSoundOnce = false;

    public Component[] myChildren;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.GetComponent<Rigidbody2D>().mass > 0)
        {
            collision.gameObject.transform.parent = gameObject.transform;
            animator.SetBool("isPressed", true);
            if(isPlatformButton == true && !isDisappearing) {
                enablePlatform();
            }
            if(isDisappearing && isPlatformButton)
            {
               // collision.gameObject.transform.parent = null;
                Unparent();
                platform.SetActive(false);
            }
            if(isWorldChangeButton == true) {

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.GetComponent<Rigidbody2D>().mass > 0 ){
            animator.SetBool("isPressed", false);
            collision.gameObject.transform.parent = null;
            playSoundOnce = false;
            SoundManager.instance.platDissapear();
            if (isDisappearing && isPlatformButton)
            {
                print("Disappear");
                platform.SetActive(true);
            }
            if (isPlatformButton == true && !isDisappearing)
            {
                disablePlatform();
            }

        }
    }

    //Enables a platform and updates the sprite and collider
    private void enablePlatform()
    {
        if (!playSoundOnce)
        {
            platform.GetComponent<BoxCollider2D>().enabled = true;
            platform.GetComponent<SpriteRenderer>().sprite = active;
            SoundManager.instance.platAppear();
            playSoundOnce = true;
        }
    }

    //Disables a platform and updates the sprite and collider
    private void disablePlatform()
    {
        if (isPlatformButton == true)
        {
            platform.GetComponent<BoxCollider2D>().enabled = false;
            platform.GetComponent<SpriteRenderer>().sprite = inactive;
        }

    }

    void Unparent() {
        myChildren = platform.GetComponentsInChildren<Component>();
        for(int i = 0; i < myChildren.Length; i++) {
            if(myChildren[i].CompareTag("Player1") || myChildren[i].CompareTag("Player2")) {
                myChildren[i].transform.parent = null;
            }
        }
    }
}
