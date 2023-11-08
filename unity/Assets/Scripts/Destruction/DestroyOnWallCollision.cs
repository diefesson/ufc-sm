using UnityEngine;

public class DestroyOnWallCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) => ProcessCollision(collision.gameObject, "trig");

    void OnCollisionEnter2D(Collision2D collision) => ProcessCollision(collision.gameObject, "coli");

    private void ProcessCollision(GameObject other, string ty)
    {
        print(ty + " " + other.name.ToString());
        if (other.GetComponent<Wall>() != null)
            Destroy(gameObject);
    }
}
