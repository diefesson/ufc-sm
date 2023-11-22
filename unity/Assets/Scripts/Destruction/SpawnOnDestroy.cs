using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnOnDestruction : MonoBehaviour
{

    [Serializable]
    public class Entry
    {
        public int weight;
        public GameObject gameObject;
    }

    public List<Entry> droptable;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
            return;
        var weights = droptable.Select(e => e.weight);
        var index = Util.WeightedIndex(weights);
        var entry = droptable[index];
        if (entry.gameObject != null)
        {
            Instantiate(entry.gameObject).transform.position = transform.position;
        }
    }

}
