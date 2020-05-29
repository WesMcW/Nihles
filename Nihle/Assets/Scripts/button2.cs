using mover;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2 : button
{
    override protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.GetComponent<Rigidbody2D>().mass > 0)
        {
            if (!colliders.Contains(collision.gameObject)) colliders.Add(collision.gameObject);

            collision.gameObject.transform.parent = gameObject.transform;
            animator.SetBool("isPressed", true);

            if (!playSoundOnce)
            {
                SoundManager.instance.platAppear();
                playSoundOnce = true;
            }

            platform.GetComponent<movingPlatforms>().stopped = false;
        }
    }

    override protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.GetComponent<Rigidbody2D>().mass > 0)
        {

            colliders.Remove(collision.gameObject);
            if (colliders.Count == 0)
            {
                animator.SetBool("isPressed", false);
                collision.gameObject.transform.parent = null;
                playSoundOnce = false;
                SoundManager.instance.platAppear();

                platform.GetComponent<movingPlatforms>().stopped = true;
            }
        }
    }
}
