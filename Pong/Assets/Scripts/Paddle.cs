using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour {

    [SerializeField] float speed;
    [Header("Key Setup")]
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;
    [Header("Points")]
    [SerializeField] TextMeshProUGUI score;
    public int currentPoint;

    Rigidbody2D myRigidbody;

    void Start() {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        ResetPoints();
    }

    void Update() {
        if (Input.GetKey(upKey)) {
            myRigidbody.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
        } else if (Input.GetKey(downKey)) {
            myRigidbody.MovePosition(transform.position + transform.up * -speed * Time.deltaTime);
        }
    }

    void ResetPoints() {
        currentPoint = 0;
    }

    public void AddPoint() {
        currentPoint++;
        score.text = currentPoint.ToString();
    }
}
