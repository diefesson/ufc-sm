using System.Linq;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{

    public float lookahead = 1;

    public float smoothing = 0.1f;

    void FixedUpdate()
    {
        var target = Player.Players.FirstOrDefault();
        if (target == null)
            return;
        var targetRb = target.GetComponent<Rigidbody2D>();
        var oldPosition = new Vector2(transform.position.x, transform.position.y);
        var targetPosition = targetRb.position;
        var targetVelocity = targetRb.velocity;
        var lookaheadPosition = targetPosition + lookahead * targetVelocity.normalized;
        var smoothPosition = Vector2.Lerp(oldPosition, lookaheadPosition, smoothing);
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z);
    }
}
