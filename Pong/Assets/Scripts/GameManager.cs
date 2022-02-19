using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle player1;
    [SerializeField] private Paddle player2;
    [SerializeField] private TextMeshProUGUI press;
    [SerializeField] private GameObject P1NameInput;
    [SerializeField] private GameObject P2NameInput;
    public static GameManager instance;

    void Awake() {
        instance = this;
    }

    public void MenuGame() {
        P1NameInput.SetActive(true);
        P2NameInput.SetActive(true);
        player1.score.gameObject.SetActive(false);
        player2.score.gameObject.SetActive(false);
    }

    public void StartGame() {
        press.gameObject.SetActive(false);
        P1NameInput.SetActive(false);
        P2NameInput.SetActive(false);
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
