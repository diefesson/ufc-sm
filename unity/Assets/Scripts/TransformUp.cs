using UnityEngine;

public class TransformUp : MonoBehaviour
{

    public float speed;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;        
    }
}
