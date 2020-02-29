using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove : MonoBehaviour
{
    public float speed;
    private float timer = 10;
    private void Update() {
        timer -= Time.deltaTime;
        transform.Translate(Vector2.right * Time.deltaTime);

        if(timer <= 0) {
            Destroy(gameObject);
        }
    }
}
