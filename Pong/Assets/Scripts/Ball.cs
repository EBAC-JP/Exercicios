using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Vector3 speed;
    [SerializeField] string playerTag = "Player";

    // Update is called once per frame
    void Update() {
        transform.Translate(speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collission) {
        if (collission.gameObject.CompareTag(playerTag)) {
            speed.x *= -1;
        } else {
            speed.y *= -1;
        }
    }
}
