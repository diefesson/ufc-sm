using UnityEngine;

public class DestroyOnHealth : MonoBehaviour
{
    private HealthProp healthProp;
    void Start()
    {
        healthProp = GetComponent<HealthProp>();
    }

    void Update()
    {
        if (healthProp.Health <= 0)
            Destroy(gameObject);
    }
}
