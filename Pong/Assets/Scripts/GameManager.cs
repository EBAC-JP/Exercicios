using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle player1;
    [SerializeField] private Paddle player2;
    [SerializeField] TextMeshProUGUI press;
    public static GameManager instance;

    void Awake() {
        instance = this;
    }

    public void StartGame() {
        press.gameObject.SetActive(false);
    }

    public void ResetPosition() {
        ball.ResetBall();
    }

    public void EndGame() {
        press.gameObject.SetActive(true);
        ball.EndGame();
        player1.EndGame();
        player2.EndGame();
    }
}
