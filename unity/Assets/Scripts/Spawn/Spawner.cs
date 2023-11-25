using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float range = 1f;

    public IEnumerable<GameObject> Spawn(int quantity, GameObject original)
    {
        return Enumerable.Range(0, quantity).Select(_ =>
        {
            var gameObject = Instantiate(original);
            gameObject.transform.position = transform.position + (Vector3)(range * UnityEngine.Random.insideUnitCircle);
            return gameObject;
        });
    }

}
