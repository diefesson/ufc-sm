using UnityEngine;

[System.Serializable]
public class Weapon
{
    public GameObject bullet;
    public int shotCount;
    public float arc;
    public float spread;
    public float rate;
    public int ammo;
}

public class WeaponManager : MonoBehaviour
{

    public Weapon primaryWeapon;
    public Weapon fallbackWeapon;

    public Weapon currentWeapon { get { return primaryWeapon.ammo != 0 ? primaryWeapon : fallbackWeapon; } }


}
