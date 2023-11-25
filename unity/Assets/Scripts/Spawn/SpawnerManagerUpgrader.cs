using System.Collections;
using UnityEngine;

public class SpawnerManagerUpgrader : MonoBehaviour
{

    public int limitChange = 1;
    public float interval = 10;

    private SpawnerManager sm;

    private void Start()
    {
        sm = GetComponent<SpawnerManager>();
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            sm.limit += limitChange;
        }
    }
}
