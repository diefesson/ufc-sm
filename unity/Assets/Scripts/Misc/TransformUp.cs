using UnityEngine;

public class TransformUp : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
