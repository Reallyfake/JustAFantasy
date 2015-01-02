﻿using UnityEngine;
using System.Collections;

public class WeaponChuck : jfWeapon {

    private GameObject shotSpawn;
    public GameObject shoot;

    private float lastShotTime = 0f;
    

	// Use this for initialization
	void Start () {
        base.OnStart();
        shotSpawn = transform.GetChild(0).gameObject;
	}

    public override void OpenFire()
    {
        if((Time.time - lastShotTime) >= fireRatio && (Ammo>0 || Ammo == -1))
        {
            
                if (anim != null)
                    anim.SetTrigger("isShooting");
                GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;
			o.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
                
            
            lastShotTime = Time.time;
            if(Ammo != -1)
                Ammo--;
        }
    }
}
