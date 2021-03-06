﻿using UnityEngine;
using System.Collections;

public class WeaponWTFireworks : jfWeapon {

    private GameObject shotSpawn;
    public GameObject shoot;

    private float lastShotTime = 0f;

	private AudioSource audioWeapon;
    

	// Use this for initialization
	void Start () {
        base.OnStart();
        shotSpawn = transform.GetChild(0).gameObject;
		audioWeapon = this.GetComponent<AudioSource>() as AudioSource;
	}

    public override void OpenFire()
    {
        if((Time.time - lastShotTime) >= fireRatio && (Ammo>0 || Ammo == -1))
        {
			if (audioWeapon != null){
				audioWeapon.Play();
			}
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("JoyY")>=0.1f)
            {
                if (anim != null)
                    anim.SetTrigger("isShootingUp");
				GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;
				(o.GetComponent<RandomMover>() as RandomMover).Xprobability = 0.5f;
				(o.GetComponent<RandomMover>() as RandomMover).Yprobability = 0.7f;
            }
            else
            {
                if (anim != null)
                    anim.SetTrigger("isShooting");
                GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;
                if (transform.lossyScale.x < 0)
                    (o.GetComponent<RandomMover>() as RandomMover).Xspeed *= -1;
            }
            lastShotTime = Time.time;
            if(Ammo != -1)
                Ammo--;
        }
    }
}
