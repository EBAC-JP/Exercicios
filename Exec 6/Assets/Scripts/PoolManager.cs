using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    [SerializeField] GameObject prefab;
    [SerializeField] int amount;
    private List<GameObject> pooledObjects;

    void Awake() {
        StartPool();
    }

    private void StartPool() {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amount; i++) {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        foreach (var obj in pooledObjects) {
            if (!obj.activeInHierarchy) {
                return obj;
            }
        }
        return null;
    }
}
