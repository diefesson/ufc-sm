using System.Linq;
using UnityEngine;

public class FireAndForget : MonoBehaviour
{

    public float speed = 16;

    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        var player = Player.Players.FirstOrDefault();
        if (player != null)
        {
            direction = (player.transform.position - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
