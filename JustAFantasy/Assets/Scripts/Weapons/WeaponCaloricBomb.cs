using UnityEngine;
using System.Collections;

public class WeaponCaloricBomb : jfWeapon
{

    private GameObject shotSpawn;
    public GameObject shoot;

    private float lastShotTime = 0f;

	private AudioSource audioWeapon;

    // Use this for initialization
    void Start()
    {
        base.OnStart();
        shotSpawn = transform.GetChild(0).gameObject;
		audioWeapon = this.GetComponent<AudioSource>() as AudioSource;
        
    }

    public override void OpenFire()
    {
        if ((Time.time - lastShotTime) >= fireRatio && (Ammo > 0 || Ammo == -1))
        {
			if (audioWeapon != null){
				audioWeapon.Play();
			}
            
                GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;
			if (transform.lossyScale.x < 0)
				(o.GetComponent<CandyMover>() as CandyMover).direction *= -1;
         
            lastShotTime = Time.time;

            if (anim != null)
                anim.SetTrigger("isShooting");

            if (Ammo != -1)
                Ammo--;
        }
    }
}