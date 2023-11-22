using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Util
{
    public static int WeightedIndex(IEnumerable<int> weights)
    {
        var sum = weights.Sum();
        var subsum = 0;
        var value = Random.Range(0, sum);
        foreach (var (w, i) in weights.Select((w, i) => (w, i))) 
        {
            subsum += w;
            if (value < subsum)
            {
                return i;
            }
        }
        return -1; // Impossible case
    }
}
