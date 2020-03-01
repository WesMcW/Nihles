using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectUI : MonoBehaviour
{
    public Image skullOne, skullTwo, skullThree;
    public Image heartOne, heartTwo, heartThree;

    public Sprite filledHeart;
    public Sprite filledSkull;

    public GameObject playerOne;
    public GameObject playerTwo;

    private void Awake() {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
    }

    private void Update() {
        if (playerOne.GetComponent<PlayerInteract>().sadCollect == 1) {
            skullOne.sprite = filledSkull;
        } else if (playerOne.GetComponent<PlayerInteract>().sadCollect == 2) {
            skullTwo.sprite = filledSkull;
        } else if (playerOne.GetComponent<PlayerInteract>().sadCollect == 3) {
            skullThree.sprite = filledSkull;
        }

        if (playerTwo.GetComponent<PlayerInteract>().hapCollect == 1) {
            heartOne.sprite = filledHeart;
        } else if (playerTwo.GetComponent<PlayerInteract>().hapCollect == 2) {
            heartTwo.sprite = filledHeart;
        } else if (playerTwo.GetComponent<PlayerInteract>().hapCollect == 3) {
            heartThree.sprite = filledHeart;
        }
    }
}
