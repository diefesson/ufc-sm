using UnityEngine;

public class Spinner : MonoBehaviour
{

    public float speed = 360;

    void Update()
    {
        var euler = transform.rotation.eulerAngles;
        var x = euler.x;
        var y = euler.y;
        var z = euler.z + speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(x, y, z);
    }
}
