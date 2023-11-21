using System.Linq;
using UnityEngine;

public class FollowerAi : MonoBehaviour
{

    public float accel = 1;
    public float maxSpeed = 4;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var target = FindNearestPlayer();
        if (target != null)
        {
            var direction = (target.transform.position - transform.position).normalized;
            rb.velocity += (Vector2)direction * accel * Time.deltaTime;
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }

    private GameObject FindNearestPlayer()
    {
        return Player.Players.OrderBy(p => Vector3.Distance(transform.position, p.transform.position))
            .FirstOrDefault();
    }
}
