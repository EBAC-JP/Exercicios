using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EbacUtils {
    
    public static void SetPositionZero(this Transform t) {
        t.position = Vector3.zero;
    }

    public static void SetPositionZero(this GameObject t) {
        t.transform.position = Vector3.zero;
    }

    public static T GetRandom<T>(List<T> list) {
        return list[Random.Range(0, list.Count)];
    }

}
