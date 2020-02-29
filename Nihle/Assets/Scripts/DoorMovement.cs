using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
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
            usedDoor.transform.position = otherDoor.transform.position;
            if (usedDoor.layer == LayerMask.NameToLayer("Right")) usedDoor.layer = LayerMask.NameToLayer("Left");
            else usedDoor.layer = LayerMask.NameToLayer("Right");

            // other things that might be needed in swap
        }

        usedDoor = null;
    }
}
