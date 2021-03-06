﻿using UnityEngine;
using System.Collections;

public class WeaponChuck : jfWeapon {

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
            
                if (anim != null)
                    anim.SetTrigger("isShooting");

			Transform cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
			Vector3 chatKills = new Vector3 (cam.position.x, cam.position.y, transform.position.z);
			GameObject o = Instantiate(shoot,chatKills , transform.rotation) as GameObject;
			o.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
                
            
            lastShotTime = Time.time;
            if(Ammo != -1)
                Ammo--;
        }
    }
}
