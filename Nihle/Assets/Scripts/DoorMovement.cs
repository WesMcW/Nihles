using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public bool doorInUse = false;
    public bool stayOnSide;
    public GameObject otherDoor;
    Animator myAnim, otherAnim;

    public GameObject usedDoor;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        otherAnim = otherDoor.GetComponent<Animator>();
    }

    public void useDoor(GameObject player)
    {
        usedDoor = player;

        myAnim.SetTrigger("Door");
        otherAnim.SetTrigger("Door");
    }

    public void teleport()
    {
        if (usedDoor != null)
        {
            SoundManager.instance.playDoor();
            usedDoor.transform.position = otherDoor.transform.position;
            if (!stayOnSide) {
                if (usedDoor.layer == LayerMask.NameToLayer("Right")) usedDoor.layer = LayerMask.NameToLayer("Left");
                else usedDoor.layer = LayerMask.NameToLayer("Right");
            }
            // other things that might be needed in swap
        }

        usedDoor = null;
    }

    public void canUseDoor()
    {
        doorInUse = false;
        otherDoor.GetComponent<DoorMovement>().doorInUse = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!doorInUse)
        {
            if (collision.CompareTag("Player1") && Input.GetButton("PlayerOneInteract"))
            {
                useDoor(collision.gameObject);
                doorInUse = true;
                otherDoor.GetComponent<DoorMovement>().doorInUse = true;
            }
            if (collision.CompareTag("Player2") && Input.GetButton("PlayerTwoInteract"))
            {
                useDoor(collision.gameObject);
                doorInUse = true;
                otherDoor.GetComponent<DoorMovement>().doorInUse = true;
            }
        }
    }
}
