using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    [Serializable]
    public struct Shoot
    {
        public GameObject bullet;
        public float delay;
    }

    public List<Shoot> shoots;

    public float rest = 1;

    public void Start()
    {
        StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            foreach (var shoot in shoots)
            {
                yield return new WaitForSeconds(shoot.delay);
                Instantiate(shoot.bullet, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(rest);
        }
    }

}
