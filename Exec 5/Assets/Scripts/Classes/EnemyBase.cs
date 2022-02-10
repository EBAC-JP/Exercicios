using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IEnemy {
    [SerializeField] protected Enemy data;
    private int _currentLife;

    void Awake() {
        _currentLife = data.totalLife;
    }

    public void Kill() {
        Destroy(gameObject);
    }

    public void Damage(int damage) {
        _currentLife -= damage;
        StartCoroutine(OnDamage());
        if (_currentLife <= 0) Kill();
    }

    public virtual IEnumerator OnDamage() {
        Debug.Log("OnDamage não implementado!");
        yield return new WaitForSeconds(0.1f);
    }
}
