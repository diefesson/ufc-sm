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

    public int playerMinRange = 0;

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
        double PlayerDistance(Spawner s) => Player.Players.Select(p => (p.transform.position - s.transform.position).magnitude).Min();
        var validSpawners = (
                from spawner in spawners
                where playerMinRange <= PlayerDistance(spawner)
                orderby PlayerDistance(spawner)
                select spawner
            ).ToArray();
        var weights = Enumerable.Range(1, validSpawners.Count()).Reverse();
        var index = Util.WeightedIndex(weights);
        return validSpawners[index];
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
