using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{

    public Vector2 speed;
    public bool local;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var movement = speed * Time.fixedDeltaTime;
        if (local)
        {
            movement *= rb.rotation;
        }
        rb.MovePosition(rb.position + movement);
    }
}
