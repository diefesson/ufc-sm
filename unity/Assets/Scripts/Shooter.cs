using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Shoot
{
    public float delay;
    public GameObject bullet;
}

public class Shooter : MonoBehaviour
{
    public List<Shoot> shoots;

    public List<int> levels;

    public float rest = 1;

    private bool firing;

    public void Fire()
    {
        if (!firing)
        {
            firing = true;
            StartCoroutine(FireCoroutine());
        }
    }

    private IEnumerator FireCoroutine()
    {
        foreach(var shoot in shoots)
        {
            yield return new WaitForSeconds(shoot.delay);
            Instantiate(shoot.bullet, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(rest);
        firing = false;
    }
}
