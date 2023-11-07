using System;
using UnityEngine;

public class HealthProp : MonoBehaviour
{

    [SerializeField]
    private int _health = 1;

    [SerializeField]
    private int _maxHealth = 4;

    public int Health
    {
        get => _health;
        set => _health = Math.Clamp(value, 0, MaxHealth);
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            _maxHealth = value;
            _health = Math.Clamp(value, 0, MaxHealth);
        }
    }
}
