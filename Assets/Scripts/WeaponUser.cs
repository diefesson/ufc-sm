using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponUser : MonoBehaviour
{

    public GameObject gunpoint;

    private bool fire;

    private float sinceLast;

    private WeaponManager wm;

    void Start()
    {
        wm = GetComponent<WeaponManager>();
    }

    void Update()
    {
        sinceLast += Time.deltaTime;
        if (fire)
            TryFire();
    }

    private void TryFire()
    {
        var weapon = wm.currentWeapon;
        var weaponDelay = 1 / weapon.rate;
        if (weapon.ammo == 0 || sinceLast < weaponDelay)
            return;
        InstantiateBullets(weapon);
        sinceLast = 0;
        if (weapon.ammo > 0)
            weapon.ammo--;
    }

    private void InstantiateBullets(Weapon weapon)
    {
        float baseAngle = 0, step = 0;
        if (weapon.shotCount > 1)
        {
            baseAngle = -weapon.arc / 2;
            step = weapon.arc / (weapon.shotCount - 1);
        }
        for (int i = 0; i < weapon.shotCount; i++)
        {
            var angle = baseAngle + Random.Range(-1f, 1f) * weapon.spread / 2;
            var rotation = gunpoint.transform.rotation * Quaternion.AngleAxis(angle, Vector3.forward);
            var instance = Instantiate(weapon.bullet, gunpoint.transform.position, rotation);
            instance.transform.rotation = rotation;
            baseAngle += step;
        }

    }

    public void OnFire(InputValue inputValue) => fire = inputValue.isPressed;
}
