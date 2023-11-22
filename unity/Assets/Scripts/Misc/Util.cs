using System.Collections.Generic;
using System.Linq;

public class Util
{
    public static int WeightedIndex(IEnumerable<int> weights)
    {
        var sum = weights.Sum();
        var subsum = 0;
        var value = UnityEngine.Random.Range(0, sum);
        foreach (var (w, i) in weights.Select((w, i) => (w, i)))
        {
            subsum += w;
            if (value < subsum)
            {
                return i;
            }
        }
        return weights.Count() - 1;
    }
}
