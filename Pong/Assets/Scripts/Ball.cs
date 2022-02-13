using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Vector3 speed;
    [SerializeField] string playerTag = "Player";
    [Header("Players")]
    [SerializeField] Paddle player1;
    [SerializeField] Paddle player2;

    Vector3 _currentSpeed, _defaultPosition;
    bool _canMove;

    void Awake() {
        _canMove = false;
        _defaultPosition = transform.position;
    }
    void Update() {
        if (_canMove) transform.Translate(_currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collission) {
        if (collission.gameObject.CompareTag(playerTag)) {
            _currentSpeed.x *= -1.1f;
        } else {
            _currentSpeed.y *= -1.1f;
        }
    }

    public void ResetBall() {
        _canMove = false;
        transform.position = _defaultPosition;
        Invoke(nameof(StartBall), 1f);
    }

    public void StartBall() {
        _currentSpeed = speed;
        if (player1.currentPoint > player2.currentPoint) _currentSpeed.x *= -1;
        _canMove = true;
    }
}
