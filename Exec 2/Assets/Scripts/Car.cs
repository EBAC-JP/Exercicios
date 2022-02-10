using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(MoveCar());
    }

    IEnumerator MoveCar() {
        transform.DOMoveZ(80f, 8f);
        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
