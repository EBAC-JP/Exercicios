using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bus : MonoBehaviour {

    [SerializeField] float duration;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(MoveBus());
    }

    IEnumerator MoveBus() {
        transform.DOMoveZ(43f, duration);
        yield return new WaitForSeconds(duration + 1);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -transform.localScale.z);
        transform.DOMoveX(4f, 2);
        yield return new WaitForSeconds(2f);
        transform.DOMoveZ(-43f, duration);
    }
}
