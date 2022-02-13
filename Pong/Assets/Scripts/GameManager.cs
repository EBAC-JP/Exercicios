using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [SerializeField] Ball ball;
    public static GameManager instance;

    void Awake() {
        instance = this;
    }

    public void ResetPosition() {
        ball.ResetBall();
    }
}
