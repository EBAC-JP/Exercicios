using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public class ScreenBase : MonoBehaviour {

    [SerializeField] public ScreenType screenType;
    [SerializeField] List<Transform> objects;
    [SerializeField] List<Typper> listPhrases;
    [Header("Animation")]
    [SerializeField] float delay = 0.05f;
    [SerializeField] float animationDuration = 0.5f;

    [Button]
    void ShowObjects() {
        for(int i = 0; i < objects.Count; i++) {
            var obj = objects[i];
            obj.gameObject.SetActive(true);
            obj.DOScale(0, animationDuration).From().SetDelay(i * delay);
        }
        Invoke(nameof(StartTyping), 0.5f);
    }

    void StartTyping() {
        foreach (var phrase in listPhrases) {
            phrase.StartType();
        }
    }

    [Button]
    void HideObjects() {
        objects.ForEach(i => i.gameObject.SetActive(false));
    }

    public void Hide() {
        HideObjects();
        gameObject.SetActive(false);
    }

    public void Show() {
        gameObject.SetActive(true);
        ShowObjects();
    }

}

public enum ScreenType {
    Panel,
    Shop,
    Info_Panel,
    Facebook,
    Missions,
    Inventory,
    Ranking,
    Settings
}
