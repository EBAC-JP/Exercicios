using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlocks : MonoBehaviour {
    public Animator animator;
    protected bool _showing = false;

    public virtual void Click() {
        if (_showing) {
            animator.SetTrigger("Hide");
            _showing = false;
        } else {
            animator.SetTrigger("Show");
            _showing = true;
        }
    }
}