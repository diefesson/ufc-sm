using UnityEngine;

public class HealthModifier : MonoBehaviour
{

    public bool selfDestruction = true;
    public int change = -1;
    public bool affectsPlayer = true;
    public bool affectsEnemy = false;

    private void OnTriggerEnter2D(Collider2D collision) => ProcessCollision(collision.gameObject);

    private void OnCollisionEnter2D(Collision2D collision) => ProcessCollision(collision.gameObject);

    private void ProcessCollision(GameObject other)
    {
        var healthProp = other.GetComponent<HealthProp>();
        var isPlayer = other.GetComponent<Player>() != null;
        var isEnemy = other.GetComponent<Enemy>() != null;
        if (healthProp != null && (affectsPlayer && isPlayer || affectsEnemy && isEnemy))
        {
            print("1 " + healthProp.Health);
            healthProp.Health += change;
            print("2 " + healthProp.Health);
            if (selfDestruction)
            {
                Destroy(gameObject);
            }
        }
    }
}
