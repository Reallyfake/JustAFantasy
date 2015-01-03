using UnityEngine;
using System.Collections;

public class WeaponGunTar : jfWeapon {

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

			float angle = 45f;
			for (int i=0;i<8;i++){
				Instantiate(shoot, shotSpawn.transform.position, Quaternion.AngleAxis(angle*i, Vector3.forward));
			}

                
            
            lastShotTime = Time.time;
            if(Ammo != -1)
                Ammo--;
        }
    }
}
