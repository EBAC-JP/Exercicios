using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour {

    [SerializeField] private float speed;
    [Header("Key Setup")]
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [Header("Points")]
    [SerializeField] private TextMeshProUGUI score;
    public int currentPoint;
    [Header("Winner")]
    [SerializeField] private TextMeshProUGUI wonText;

    private Rigidbody2D myRigidbody;
    private Vector3 _defaultPositon;
    private bool _canMove;

    void Awake() {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _canMove = false;
        _defaultPositon = transform.position;
        wonText.gameObject.SetActive(false);
    }

    void Update() {
        if (!_canMove) return;
        if (Input.GetKey(upKey)) {
            myRigidbody.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
        } else if (Input.GetKey(downKey)) {
            myRigidbody.MovePosition(transform.position + transform.up * -speed * Time.deltaTime);
        }
    }

    void ResetPoints() {
        currentPoint = 0;
        score.text = currentPoint.ToString();
    }

    public void AddPoint() {
        currentPoint++;
        score.text = currentPoint.ToString();
    }

    public void StartPaddle() {
        wonText.gameObject.SetActive(false);
        ResetPoints();
        _canMove = true;
    }

    public void ActiveWonText() {
        wonText.gameObject.SetActive(true);
    }

    public void EndGame() {
        _canMove = false;
        transform.position = _defaultPositon;
    }
}
