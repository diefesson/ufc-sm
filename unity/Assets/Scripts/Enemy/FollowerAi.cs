using System.Linq;
using UnityEngine;

public class FollowerAi : MonoBehaviour
{

    public float speed = 4;

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
            rb.velocity = speed * direction;
        }
    }

    private GameObject FindNearestPlayer()
    {
        return Player.Players.OrderBy(p => Vector3.Distance(transform.position, p.transform.position))
            .FirstOrDefault();
    }
}
