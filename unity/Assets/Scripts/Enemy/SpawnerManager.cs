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

    public List<Entry> entries;

    private List<Spawner> spawners;

    void Start()
    {
        var localSpawners = GetComponents<Spawner>();
        if (localSpawners.Length > 0)
        {
            spawners = new List<Spawner>(localSpawners);
        }
        else
        {
            spawners = Spawner.globalSpawners;
        }
        StartCoroutine(SpawnCoroutine());
    }

    private Spawner PickSpawner()
    {
        var index = UnityEngine.Random.Range(0, spawners.Count);
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
            var spawner = PickSpawner();
            var entry = PickEntry();
            spawner.Spawn(entry.count, entry.gameObject);
            yield return new WaitForSeconds(entry.rest);
        }
    }
}
