using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IPlayer {

    [SerializeField] UnityEvent basicEvents, magicEvents;
    private bool basicAttacking = false, magicAttacking = false;
    private int basicDamage, magicDamage;
    private EnemyBase boss;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            BasicAttack();
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            MagicAttack();
        }
    }

    public void BasicAttack() {
        if (basicAttacking) {
            Debug.Log("Seu ataque basico esta em cooldown");
        } else {
            basicAttacking = true;
            basicEvents.Invoke();
            Invoke(nameof(BasicCooldown), 1.5f);
        }
    }

    public void MagicAttack() {
        if (magicAttacking) {
            Debug.Log("Seu ataque magico esta em cooldown");
        } else {
            magicAttacking = true;
            magicEvents.Invoke();
            Invoke(nameof(MagicCooldown), 3f);
        }
    }

    void BasicCooldown() {
        basicAttacking = false;
    }

    void MagicCooldown() {
        magicAttacking = false;
    }
}
