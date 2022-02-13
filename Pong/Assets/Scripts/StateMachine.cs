using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    
    public static StateMachine instance;
    enum States {
        MENU,
        PLAYING,
        RESET_BALL
    }
    Dictionary<States, StateBase> states;
    StateBase _currentState;
    bool onPlay = false;

    void Awake() {
        instance = this;
        states = new Dictionary<States, StateBase>();
        states.Add(States.MENU, new StateMenu());
        states.Add(States.PLAYING, new StatePlaying());
        states.Add(States.RESET_BALL, new StateResetBall());

        SwitchState(States.MENU);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !onPlay) {
            SwitchState(States.PLAYING);
            onPlay = true;
        }
    }

    void SwitchState(States state) {
        if (_currentState != null) _currentState.OnStateExit();
        _currentState = states[state];
        _currentState.OnStateEnter();
    }

    public void ChangeStateToReset() {
        SwitchState(States.RESET_BALL);
    }
}
