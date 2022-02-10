using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] PoolManager poolManager;
    private int totalPoints = 0;
    private bool rolling = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && !rolling) {
            rolling = true;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;
            var obj = poolManager.GetPooledObject();
            if (obj != null) {
                Cannon cannon = obj.GetComponent<Cannon>();
                cannon.StartProjectile(Camera.main.ScreenToWorldPoint(mousePosition));
                cannon.actionCallback = Score;
            }
            StartCoroutine(RollCooldown());
        }
    }

    public void Score() {
        totalPoints++;
        Debug.Log("Voce pontuou " + totalPoints + " vezes!");
    }

    IEnumerator RollCooldown() {
        yield return new WaitForSeconds(2f);
        rolling = false;
    }
}
