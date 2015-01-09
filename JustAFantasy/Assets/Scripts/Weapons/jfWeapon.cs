using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class jfWeapon : MonoBehaviour {

	public int Ammo = 0;
	public int maxAmmo = -1;
	public string weaponName = "";
	public bool unlocked = true;

    public float fireRatio = 1.0f;

    public KeyCode fastSelect;
    public Texture Thumb;

    protected Animator anim;

    protected void OnStart()
    {
        anim = gameObject.GetComponent<Animator>() as Animator;

        renderer.enabled = false;
        if (transform.parent != null)
        {
            WeaponsController wsc = transform.parent.gameObject.GetComponent<WeaponsController>() as WeaponsController;
            if(wsc != null && wsc.Equipped == this)
                renderer.enabled = true;
        }
        
    }

    public int reload(int ammo)
    {
        if (Ammo == -1)
            return ammo;
        Ammo += ammo;
        if (maxAmmo == -1)
            return 0;
        int d = maxAmmo - Ammo;
        if (d < 0)
        {
            Ammo += d;
            return -d;
        }
        else
            return 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(fastSelect) && unlocked && transform.parent != null && Ammo != 0)
        {
            transform.parent.SendMessage("ChangeWeapon", transform.gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }

    void Shoot()
    {
        OpenFire();
        if (Ammo == 0)
        {
            if (transform.parent != null)
            {
                WeaponsController wsc = transform.parent.gameObject.GetComponent<WeaponsController>() as WeaponsController;
                if (wsc != null && wsc.Equipped == this)
                {
                    for (int i = 0; i < wsc.transform.childCount; i++)
                    {
                        if ((int)(wsc.transform.GetChild(i).gameObject.GetComponent<jfWeapon>() as jfWeapon).fastSelect - 48 == 1)
                            transform.parent.SendMessage("ChangeWeapon", wsc.transform.GetChild(i).gameObject, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }

    public void setTrigger(string trigger)
    {
        if(anim != null)
            anim.SetTrigger(trigger);
    }

    public void setBool(string var, bool val)
    {
        if(anim != null)
            anim.SetBool(var, val);
    }

    abstract public void OpenFire();
}
