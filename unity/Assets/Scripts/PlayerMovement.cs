using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 move;

    private Player player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = move * player.speed;
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
