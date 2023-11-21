using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public static List<Spawner> globalSpawners { get; private set; } = new List<Spawner>();

    public float range = 1f;

    private bool isGlobalSpawner;

    void Start()
    {
        isGlobalSpawner = GetComponent<SpawnerManager>() == null;
        if (isGlobalSpawner)
        {
            globalSpawners.Add(this);
        }
    }

    void OnDestroy()
    {
        if (isGlobalSpawner)
        {
            globalSpawners.Remove(this);
        }
    }

    public void Spawn(int quantity, GameObject original)
    {
        for (int i = 0; i < quantity; i++)
        {
            var gameObject = Instantiate(original);
            gameObject.transform.position = transform.position + (Vector3)(range * UnityEngine.Random.insideUnitCircle);
        }
    }

}
