using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{

    public GameObject pivot;

    public GameObject bullet;

    private bool fire;

    private bool firing;

    private HealthProp healthProp;

    void Start()
    {
        healthProp = GetComponent<HealthProp>();
    }

    void Update()
    {
        if (fire && !firing)
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        firing = true;
        var level = healthProp.Health;
        switch (level)
        {
            case 0:
                break;
            case 1:
                InstantiateBullet(bullet, -0.3f, +0.6f, +0);
                yield return new WaitForSeconds(0.25f);
                InstantiateBullet(bullet, +0.3f, +0.6f, +0);
                yield return new WaitForSeconds(0.25f);
                break;
            case 2:
                InstantiateBullet(bullet, -0.2f, +0.6f, +0);
                InstantiateBullet(bullet, +0.2f, +0.6f, +0);
                yield return new WaitForSeconds(0.1f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +5);
                InstantiateBullet(bullet, +0.3f, +0.5f, -5);
                yield return new WaitForSeconds(0.4f);
                break;
            case 3:
                InstantiateBullet(bullet, -0.2f, +0.6f, +0);
                InstantiateBullet(bullet, +0.2f, +0.6f, +0);
                yield return new WaitForSeconds(0.1f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +5);
                InstantiateBullet(bullet, +0.3f, +0.5f, -5);
                yield return new WaitForSeconds(0.1f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +10);
                InstantiateBullet(bullet, +0.3f, +0.5f, -10);
                yield return new WaitForSeconds(0.3f);
                break;
            case 4:
                InstantiateBullet(bullet, -0.2f, +0.6f, +0);
                InstantiateBullet(bullet, +0.2f, +0.6f, +0);
                yield return new WaitForSeconds(0.1f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +5);
                InstantiateBullet(bullet, +0.3f, +0.5f, -5);
                yield return new WaitForSeconds(0.1f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +10);
                InstantiateBullet(bullet, +0.3f, +0.5f, -10);
                yield return new WaitForSeconds(0.1f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +15);
                InstantiateBullet(bullet, +0.3f, +0.5f, -15);
                yield return new WaitForSeconds(0.2f);
                break;
            default:
                print("Invalid level: " + level);
                break;
        }
        firing = false;
        yield break;
    }

    private GameObject InstantiateBullet(GameObject bullet, float x, float y, float angle)
    {
        var position = pivot.transform.position + pivot.transform.rotation * new Vector2(x, y);
        var rotation = pivot.transform.rotation * Quaternion.Euler(0, 0, angle);
        return Instantiate(bullet, position, rotation);
    }

    public void OnFire(InputValue inputValue) => fire = inputValue.isPressed;
}
