using UnityEngine;

public class FollowerCamera : MonoBehaviour
{

    public GameObject target;

    public float lookahead;

    public float smoothing;

    private Rigidbody2D targetRb;

    void Start()
    {
        targetRb = target.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var oldPosition = new Vector2(transform.position.x, transform.position.y);
        var targetPosition = targetRb.position;
        var targetVelocity = targetRb.velocity;
        var lookaheadPosition = targetPosition + lookahead * targetVelocity;
        var smoothPosition = Vector2.Lerp(oldPosition, lookaheadPosition, smoothing);
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z);
    }
}
