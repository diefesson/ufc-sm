using UnityEngine;

[ExecuteAlways]
public class SnappingFollower : MonoBehaviour
{

    public GameObject target;

    public float xSize = 1;
    public float ySize = 1;
    public float xOffset = 1;
    public float yOffset = 1;

    void Update()
    {
        if (target == null)
            return;
        var x = Snap(target.transform.position.x, xSize, xOffset);
        var y = Snap(target.transform.position.y, ySize, yOffset);
        var z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }

    private static float Snap(float value, float size, float offset)
    {
        return Mathf.Round((value - offset) / size) * size + offset;
    }
}
