using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int level = 1;
    public int maxLevel = 4;

    public static List<GameObject> Players { get; private set; } = new List<GameObject>();

    void Start() => Players.Add(gameObject);

    void OnDestroy() => Players.Remove(gameObject);

    public void LevelUp()
    {
        level = Math.Clamp(level + 1, 0, maxLevel);
    }

    public void LevelDown()
    {
        level = Math.Clamp(level - 1, 0, maxLevel);
    }

}
