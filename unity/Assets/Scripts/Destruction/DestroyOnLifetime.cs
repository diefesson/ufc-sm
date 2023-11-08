using UnityEngine;

public class DestroyOnLifetime : MonoBehaviour
{
    public float lifetime = 2;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
