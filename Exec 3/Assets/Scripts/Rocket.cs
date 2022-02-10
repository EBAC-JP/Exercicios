using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rocket : MonoBehaviour {

    #region Variables
    [SerializeField] int launchTime;
    [SerializeField] float position;
    
     private float duration = 10f;
    #endregion

    #region Unity Methods
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            duration--;
            Debug.Log($"Tempo de dura��o diminuido para: {duration}");
        } else if (Input.GetKeyDown(KeyCode.D)) {
            duration++;
            Debug.Log($"Tempo de dura��o aumentado para: {duration}");
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Lan�amento iniciado");
            StartCoroutine(Coutdown());
        }
    }

    void OnDestroy() {
        Debug.Log("Lan�amento foi um sucesso");
    }
    #endregion

    #region Methods
    IEnumerator Coutdown() {
        Debug.Log("Contagem regressiva iniciada");
        for(int i = 1; i <= launchTime; i++) {
            Debug.Log(i);
            yield return new WaitForSeconds(1f);
        }
        Launch();
    }

    void Launch() {
        Debug.Log("Decolando");
        transform.DOMoveY(position, duration);
        Destroy(gameObject, duration + 1);
    }
    #endregion
}
