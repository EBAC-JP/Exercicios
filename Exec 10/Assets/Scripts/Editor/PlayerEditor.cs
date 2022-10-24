using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Player myPlayer = (Player)target;

        if (GUILayout.Button("Whats my name?")) myPlayer.PrintName();
        if (GUILayout.Button("Create Player")) myPlayer.CreatePlayer();
    }

}
