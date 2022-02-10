using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animal {
    Dog,
    Cat,
    Bird
}

public class PrintAnimals : MonoBehaviour {

    # region Variaveis
    [SerializeField] Animals[] animals;
    # endregion

    # region Metodos Unity
    void Start() {
        Debug.Log("Nos temos: " + animals.Length + " animais!");
        Debug.Log("Tecle o numero do animal desejado (1 - 9):");
    }

    // Update is called once per frame
    void Update() {
        CheckInput();
    }
    #endregion

    #region Metodos
    void CheckInput() {
        foreach (var animal in animals) {
            if (Input.GetKeyDown(animal.key)) {
                CheckTypeAnimal(animal);
            }   
        }
    }

    void CheckTypeAnimal(Animals animal) {
        switch(animal.type) {
            case Animal.Dog:
                animal.ShowInfo("cachorro");
                break;
            case Animal.Cat:
                animal.ShowInfo("gato");
                break;
            case Animal.Bird:
                animal.ShowInfo("passaro");
                break;
            default:
                Debug.Log("Nenhum tipo de animal encontrado!");
                break;
        }
    }
    #endregion
}

[System.Serializable]
public class Animals {

    #region Variaveis
    [SerializeField] string name;
    [SerializeField] public Animal type;
    [SerializeField] public KeyCode key;
    #endregion

    #region Metodos
    public void ShowInfo(string animalType) {
        Debug.Log("Ola me chamo " + this.name + " e eu sou um " + animalType);
    }
    #endregion
}
