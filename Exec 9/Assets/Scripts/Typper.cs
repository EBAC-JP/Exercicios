using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class Typper : MonoBehaviour {

    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] float timeBetweenLetters;
    [SerializeField] string phrase;

    [Button]
    public void StartType() {
        StartCoroutine(Type(phrase));
    }

    IEnumerator Type(string textToType) {
        textMesh.text = "";
        foreach (var c in textToType.ToCharArray()) {
            textMesh.text += c;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }

}
