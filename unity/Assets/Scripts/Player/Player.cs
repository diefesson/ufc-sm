using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static List<GameObject> Players { get; private set; } = new List<GameObject>();

    void Start()
    {
        Players.Add(gameObject);
    }

    void OnDestroy()
    {
        Players.Remove(gameObject);
    }

}
