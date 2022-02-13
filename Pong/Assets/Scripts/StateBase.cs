using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase {
    public virtual void OnStateEnter() {
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
        GameObject obj = GameObject.Find("Canvas/Press");
        obj.SetActive(false);
    }
}

public class StatePlaying : StateBase {
    public override void OnStateEnter() {
        GameObject obj = GameObject.Find("Ball");
        obj.GetComponent<Ball>().StartBall();
    }
}

public class StateResetBall : StateBase {
    public override void OnStateEnter() {
        GameManager.instance.ResetPosition();
    }
}