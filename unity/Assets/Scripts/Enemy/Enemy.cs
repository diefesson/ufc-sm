using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static List<GameObject> Enemies { get; private set; } = new List<GameObject>();

    void Start()
    {
        Enemies.Add(gameObject);
    }

    void OnDestroy()
    {
        Enemies.Remove(gameObject);
    }

}
