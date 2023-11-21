using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class SnappingFollower : MonoBehaviour
{

    public float xSize = 1;
    public float ySize = 1;
    public float xOffset = 1;
    public float yOffset = 1;

    void Update()
    {
        var player = Player.Players.FirstOrDefault();
        if (player == null)
            return;
        var x = Snap(player.transform.position.x, xSize, xOffset);
        var y = Snap(player.transform.position.y, ySize, yOffset);
        var z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }

    private static float Snap(float value, float size, float offset)
    {
        return Mathf.Round((value - offset) / size) * size + offset;
    }
}
