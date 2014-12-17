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

    protected Animator anim;

    protected void OnStart()
    {
        anim = gameObject.GetComponent<Animator>() as Animator;
        if (transform.parent != null && transform.parent.gameObject.tag == "Player")
            renderer.enabled = true;
        else
            renderer.enabled = false;
    }

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

    void Update()
    {
        if (Input.GetKeyDown(fastSelect) && unlocked && transform.parent != null && transform.parent.gameObject.tag != "Player")
        {
            transform.parent.SendMessage("ChangeWeapon", transform.gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }

    void Shoot()
    {
        OpenFire();
    }

    public void setTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void setBool(string var, bool val)
    {
        anim.SetBool(var, val);
    }

    abstract public void OpenFire();
}
