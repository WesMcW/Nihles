using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mover {
    public class movingPlatforms : MonoBehaviour {
        private GameObject platform;
        public float speed;
        public float timer = 0;
        //Dictates whether or not the platform is meant to push the player only. Thus allowing the player to not become a child
        //of the platform
        public bool isPush;
        [Tooltip("These are the two points that the platform will move towards.")]
        [SerializeField] private GameObject pointOne, pointTwo;
        private void Awake() {
            platform = this.gameObject;
        }

        private void Update() {
            
            timer += Time.deltaTime / speed;
            if(timer >= 1) {
                timer = 0;
                GameObject tmp = pointOne;
                pointOne = pointTwo;
                pointTwo = tmp;
            }
           gameObject.transform.position = Vector2.Lerp(pointOne.transform.position, pointTwo.transform.position, timer);
           
            
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (isPush == false) {
                if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")) {
                    collision.gameObject.transform.parent = gameObject.transform;
                }
            }
        }
        private void OnCollisionExit2D(Collision2D collision) {
            if (isPush == false) {
                if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")) {
                    collision.gameObject.transform.parent = null;
                }
            }
        }
    }
}