using UnityEngine;

public class LevelPowerup : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.LevelUp();
            Destroy(gameObject);
        }
    }
}
