using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {

    [SerializeField] GameObject playerPrefab;
    [SerializeField] int lifes;
    [SerializeField] string playerName;

    public void PrintName() {
        Debug.Log("Olá, mundo me chamo " + playerName);
    }

    public void CreatePlayer() {
        var obj = Instantiate(playerPrefab);
        obj.SetPositionZero();
    }

}
