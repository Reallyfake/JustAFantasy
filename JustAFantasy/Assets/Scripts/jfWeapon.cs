using UnityEngine;
using System.Collections;

public abstract class jfWeapon : MonoBehaviour {

	public int Ammo = 0;
	public int maxAmmo = -1;
	public string weaponName = "";

    public float fireRatio = 1.0f;

    public int reload(int ammo)
    {
        Ammo += ammo;
        int d = maxAmmo - Ammo;
        if (d < 0)
        {
            maxAmmo -= d;
            return -d;
        }
        else
            return 0;
    }

    abstract public void openFire();
}
