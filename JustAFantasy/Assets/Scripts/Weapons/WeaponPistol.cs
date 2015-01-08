using UnityEngine;
using System.Collections;

public class WeaponPistol : jfWeapon {

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

            if (Input.GetKey(KeyCode.UpArrow))
            {
                GameObject o = Instantiate(shoot, transform.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
				if (transform.lossyScale.x < 0){
					o.transform.Rotate (Vector3.right,180f);
				}
            }
            else
            {
                if (anim != null)
                    anim.SetTrigger("isShooting");
                GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;
                if (transform.lossyScale.x < 0){
					o.transform.Rotate (Vector3.up,180f);
				}
            }
            lastShotTime = Time.time;
            if(Ammo != -1)
                Ammo--;
        }
    }
}
