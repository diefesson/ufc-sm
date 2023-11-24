using System.Collections;
using System.Linq;
using UnityEngine;

public class FollowerAi : MonoBehaviour
{

    public float accel = 8;
    public float maxSpeed = 6;
    public float minRange = 0;
    public float maxRange = float.PositiveInfinity;
    public float minMoveTime = 1.0f;
    public float maxMoveTime = 3.0f;
    public float minStopTime = 0.0f;
    public float maxStopTime = 0.0f;

    private bool moveMode = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ToggleMove());
    }

    private IEnumerator ToggleMove()
    {
        while (true)
        {
            var moveTime = Random.Range(minMoveTime, maxMoveTime);
            var stopTime = Random.Range(minStopTime, maxStopTime);
            moveMode = true;
            yield return new WaitForSeconds(moveTime);
            if (stopTime == 0f)
                continue;
            moveMode = false;
            yield return new WaitForSeconds(stopTime);
        }
    }

    void FixedUpdate()
    {
        var shouldMove = false;
        if (moveMode == false)
            print(gameObject.name + " " + minStopTime.ToString() + ":" + maxStopTime.ToString());
        var target = FindNearestPlayer();
        if (target != null)
        {
            var distance = Vector3.Distance(transform.position, target.transform.position);
            shouldMove = moveMode && minRange <= distance && distance <= maxRange;
        }
        if (shouldMove)
        {
            var direction = (target.transform.position - transform.position).normalized;
            rb.velocity += (Vector2)direction * accel * Time.deltaTime;
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private GameObject FindNearestPlayer()
    {
        return Player.Players.OrderBy(p => Vector3.Distance(transform.position, p.transform.position))
            .FirstOrDefault();
    }
}
