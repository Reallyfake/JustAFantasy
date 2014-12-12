using UnityEngine;
using System.Collections;

public class WeaponBananaGun : jfWeapon
{

    private GameObject shotSpawn;
    public GameObject shoot;

    private float lastShotTime = 0f;

    // Use this for initialization
    void Start()
    {

        shotSpawn = transform.GetChild(0).gameObject;
        if (transform.parent.gameObject.tag == "player")
            renderer.enabled = true;
        else
            renderer.enabled = false;
    }

    public override void openFire()
    {
        if ((Time.time - lastShotTime) >= fireRatio && (Ammo > 0 || Ammo == -1))
        {
            GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;

            if (transform.lossyScale.x < 0)
                (o.GetComponent<LinearMover>() as LinearMover).speed *= -1;
            lastShotTime = Time.time;

            if (Ammo != -1)
                Ammo--;
        }
    }
}