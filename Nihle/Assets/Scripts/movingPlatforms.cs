using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mover {
    public class movingPlatforms : MonoBehaviour {
        private GameObject platform;

        [Header("These are the two points that the platform will move towards.")]
        [SerializeField] private GameObject pointOne;
        private void Awake() {
            platform = this.gameObject;
        }

        private void Update() {
            platform.transform.position = new Vector3(Mathf.PingPong(Time.time, 5), pointOne.transform.position.y);
        }
    }
}