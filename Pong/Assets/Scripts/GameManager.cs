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

    public void MenuGame() {
        player1.score.gameObject.SetActive(false);
        player2.score.gameObject.SetActive(false);
    }

    public void StartGame() {
        press.gameObject.SetActive(false);
        player1.score.gameObject.SetActive(true);
        player2.score.gameObject.SetActive(true);
    }

    public void RestartGame() {
        ball.StartBall();
        player1.StartPaddle();
        player2.StartPaddle();
    }

    public void ResetPosition() {
        ball.ResetBall();
    }

    public void EndGame() {
        press.text = "Press Space to Restart!";
        press.gameObject.SetActive(true);
        ball.EndGame();
        player1.EndGame();
        player2.EndGame();
    }
}
