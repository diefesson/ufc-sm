using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [Serializable]
    public struct Entry
    {
        public float rest;
        public int weight;
        public int count;
        public GameObject gameObject;
    }

    public int limit = 3;

    public Entry[] entries;

    private Spawner[] spawners;

    private List<GameObject> instances;

    void Start()
    {
        spawners = GetComponentsInChildren<Spawner>();
        instances = new List<GameObject>();
        StartCoroutine(SpawnCoroutine());
    }

    private Spawner PickSpawner()
    {
        var index = UnityEngine.Random.Range(0, spawners.Length);
        return spawners[index];
    }

    private Entry PickEntry()
    {

        var index = Util.WeightedIndex(entries.Select(e => e.weight));
        return entries[index];
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            instances.RemoveAll(i => i == null);
            if (instances.Count < limit)
            {
                var spawner = PickSpawner();
                var entry = PickEntry();
                instances.AddRange(spawner.Spawn(entry.count, entry.gameObject));
                yield return new WaitForSeconds(entry.rest);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
