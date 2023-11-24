using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{

    public GameObject pivot;

    public GameObject bullet;

    private bool firing;

    private PlayerInputActions inputActions;
    private HealthProp healthProp;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    private void Start()
    {
        healthProp = GetComponent<HealthProp>();
    }

    private void Update()
    {
        var fire = inputActions.Gameplay.Fire.IsPressed();
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
                yield return new WaitForSeconds(0.125f);
                InstantiateBullet(bullet, +0.3f, +0.6f, +0);
                yield return new WaitForSeconds(0.125f);
                break;
            case 2:
                InstantiateBullet(bullet, -0.2f, +0.6f, +0);
                InstantiateBullet(bullet, +0.2f, +0.6f, +0);
                yield return new WaitForSeconds(0.05f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +5);
                InstantiateBullet(bullet, +0.3f, +0.5f, -5);
                yield return new WaitForSeconds(0.2f);
                break;
            case 3:
                InstantiateBullet(bullet, -0.2f, +0.6f, +0);
                InstantiateBullet(bullet, +0.2f, +0.6f, +0);
                yield return new WaitForSeconds(0.05f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +5);
                InstantiateBullet(bullet, +0.3f, +0.5f, -5);
                yield return new WaitForSeconds(0.05f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +10);
                InstantiateBullet(bullet, +0.3f, +0.5f, -10);
                yield return new WaitForSeconds(0.15f);
                break;
            case 4:
                InstantiateBullet(bullet, -0.2f, +0.6f, +0);
                InstantiateBullet(bullet, +0.2f, +0.6f, +0);
                yield return new WaitForSeconds(0.05f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +5);
                InstantiateBullet(bullet, +0.3f, +0.5f, -5);
                yield return new WaitForSeconds(0.05f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +10);
                InstantiateBullet(bullet, +0.3f, +0.5f, -10);
                yield return new WaitForSeconds(0.05f);
                InstantiateBullet(bullet, -0.3f, +0.5f, +15);
                InstantiateBullet(bullet, +0.3f, +0.5f, -15);
                yield return new WaitForSeconds(0.1f);
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
}
