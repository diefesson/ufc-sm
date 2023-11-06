using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int level = 1;
    public int maxLevel = 4;
    public float speed;

    public void LevelUp()
    {
        level = Math.Clamp(level + 1, 0, maxLevel);
    }

    public void LevelDown()
    {
        level = Math.Clamp(level - 1, 0, maxLevel);
    }

}
