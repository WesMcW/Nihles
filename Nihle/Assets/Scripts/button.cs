using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject platform;

    public bool isPlatformButton;
    public bool isWorldChangeButton;
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")){
            if(isPlatformButton == true) {
                platform.SetActive(true);
            }
            if(isWorldChangeButton == true) {

            }
        }
    }
}
