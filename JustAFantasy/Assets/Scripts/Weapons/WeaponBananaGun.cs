using UnityEngine;
using System.Collections;

public class WeaponBananaGun : jfWeapon
{

    private GameObject shotSpawn;
    public GameObject shoot;
    public KeyCode fastSelect;

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

    void Update()
    {
        if (Input.GetKeyDown(fastSelect) && transform.parent.gameObject.tag != "player")
        {
            if (transform.parent != null && transform.parent.gameObject.transform.parent != null)
            {
                GameObject weapons = transform.parent.gameObject;
                GameObject levelController = weapons.transform.parent.gameObject;
                GameObject player = levelController.transform.GetChild(3).gameObject;
                GameObject oldWeapon = player.transform.GetChild(1).gameObject;
                oldWeapon.transform.parent = weapons.transform;
                transform.parent = player.transform;
                transform.position = oldWeapon.transform.position;
                transform.rotation = oldWeapon.transform.rotation;
                renderer.enabled = true;
                oldWeapon.renderer.enabled = false;
            }
        }
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