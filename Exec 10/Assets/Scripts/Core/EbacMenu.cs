using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public static class EbacMenu {

    [MenuItem("Ebac/Imprime Texto")]
    public static void PrintText() {
        Debug.Log("Olá, Mundo");
    }

    [MenuItem("Ebac/Criar Player &p", false)]
    public static void CreatePlayer() {
        var obj = GameObject.FindGameObjectWithTag("Player");
        var player = obj?.GetComponent<Player>();
        if (player != null) player.CreatePlayer();
    }
}
#endif