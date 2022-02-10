using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCooldown : MonoBehaviour {


    public Animator animator;
    public UnityEvent eventCallback;

    private bool _cooldown = false;
    public void Click() {
        if (!_cooldown) {
            _cooldown = true;
            animator.SetTrigger("Click");
            Invoke(nameof(Cooldown), 1.1f);
            eventCallback?.Invoke();
        }
    }

    private void Cooldown() {
        _cooldown = false;
    }

}
