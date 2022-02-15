using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase {
    public virtual void OnStateEnter(GameObject obj = null) {
        Debug.Log("State Enter not implemented!");
    }

    public virtual void OnStateStay() {
        Debug.Log("State Stay not implemented!");
    }

    public virtual void OnStateExit() {
        Debug.Log("State Stay not implemented!");
    }
}

public class StateMenu : StateBase {
    public override void OnStateExit() {
        GameManager.instance.StartGame();
    }
}

public class StatePlaying : StateBase {
    public override void OnStateEnter(GameObject obj = null) {
        GameObject ball = GameObject.Find("Ball");
        ball.GetComponent<Ball>().StartBall();
        List<GameObject> players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        foreach(GameObject player in players) {
            player.GetComponent<Paddle>().StartPaddle();
        }
    }
}

public class StateResetBall : StateBase {
    public override void OnStateEnter(GameObject obj = null) {
        GameManager.instance.ResetPosition();
    }
}

public class StateEndGame : StateMenu {
    public override void OnStateEnter(GameObject obj = null) {
        obj.GetComponent<Paddle>().ActiveWonText();
        GameManager.instance.EndGame();
    }
}