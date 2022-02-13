using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float speed;
    [Header("Key Setup")]
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;

    
    Rigidbody2D myRigidbody;

    void Start() {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (Input.GetKey(upKey)) {
            myRigidbody.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
        } else if (Input.GetKey(downKey)) {
            myRigidbody.MovePosition(transform.position + transform.up * -speed * Time.deltaTime);
        }
    }
}
