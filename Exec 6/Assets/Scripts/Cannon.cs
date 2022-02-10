using System;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    [SerializeField] Vector3 dir;
    [SerializeField] float resetTime = 3f;
    public Action actionCallback;

    void Update() {
        transform.Translate(dir * Time.deltaTime);
    }

    public void StartProjectile(Vector3 newPosition) {
        Invoke(nameof(FinishUse), resetTime);
        transform.SetParent(null);
        transform.position = newPosition;
        gameObject.SetActive(true);
    }

    private void FinishUse() {
        actionCallback = null;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Target") {
            actionCallback?.Invoke();
            FinishUse();
            CancelInvoke();
        }
    }
}
