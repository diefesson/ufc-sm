using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Serializable]
    public struct Entry
    {
        public float time;
        public int quantity;
        public GameObject gameObject;
    }

    public float range = 1f;
    public List<Entry> entries;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            var index = UnityEngine.Random.Range(0, entries.Count);
            var entry = entries[index];
            yield return new WaitForSeconds(entry.time);
            for (int i = 0; i < entry.quantity; i++)
            {
                var gameObject = Instantiate(entry.gameObject);
                gameObject.transform.position = transform.position + (Vector3)(range * UnityEngine.Random.insideUnitCircle);
            }
        }
    }
}
