using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField] GameObject[] cars;
    [SerializeField] float time;

    float timeRemaining;

    void Start() {
        timeRemaining = time;
        Instantiate(cars[Random.Range(0, cars.Length)]);
    }

    // Update is called once per frame
    void Update() {
        if (timeRemaining > 0f) {
            timeRemaining -= Time.deltaTime; 
        } else {
            timeRemaining = time;
            Instantiate(cars[Random.Range(0, cars.Length)]);
        }
    }
}
