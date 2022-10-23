using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    [SerializeField] ScreenType clickScreen;
    [SerializeField] float finalScale;
    [SerializeField] float animationDuration;
    [Header("Play Button")]
    [SerializeField] bool isPlayButton = false;
    [SerializeField] ParticleSystem playParticle;

    Vector3 _defaultScale;
    Tween _currentTween;

    void Awake() {
        _defaultScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        _currentTween = transform.DOScale(_defaultScale * finalScale, animationDuration);
    }

    public void OnPointerExit(PointerEventData eventData) {
        _currentTween.Kill();
        transform.localScale = _defaultScale;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (isPlayButton) {
            playParticle.Play();
        } else {
            ScreenManager.Instance.ShowByType(clickScreen);
        }
    }

}
