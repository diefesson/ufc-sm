using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 12;

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
        rb.velocity = move * speed;
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
