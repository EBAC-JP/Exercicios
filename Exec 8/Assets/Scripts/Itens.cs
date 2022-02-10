using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Itens : BaseBlocks {

    public List<GameObject> itens;
    void Awake() {
        Hide();    
    }

    public override void Click() {
        if (_showing) {
            Invoke(nameof(Hide), 1f);
            animator.SetTrigger("Hide");
            _showing = false;
        } else {
            animator.SetTrigger("Show");
            StartCoroutine(Show());
            _showing = true;
        }
    }

    IEnumerator Show() {
        yield return new WaitForSeconds(1f);
        foreach(GameObject item in itens) {
            yield return new WaitForSeconds(0.1f);
            item.SetActive(true);
            item.transform.DOScale(0, 0.3f).From();
        }
    }

    void Hide() {
        foreach(GameObject item in itens) {
            item.SetActive(false);
        }
    }
}
