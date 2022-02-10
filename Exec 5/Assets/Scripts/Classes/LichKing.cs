using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichKing : EnemyBase {

    [SerializeField] MeshRenderer meshRenderer;

    public override IEnumerator OnDamage() {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
        for (var i = 1.0f; i >= 0; i -= 0.05f) {
            meshRenderer.material.SetColor("_Color", Color.Lerp(Color.white, data.colorDamage, 1 - i));
            yield return new WaitForEndOfFrame();
        }
        for (var i = 1.0f; i >= 0; i -= 0.1f) {
            meshRenderer.material.SetColor("_Color", Color.Lerp(data.colorDamage, Color.white, 1 - i));
            yield return new WaitForEndOfFrame();
        }
    }
}
