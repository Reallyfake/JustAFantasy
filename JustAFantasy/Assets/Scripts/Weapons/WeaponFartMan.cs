using UnityEngine;
using System.Collections;

public class WeaponFartMan : jfWeapon {

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
            if (Input.GetKey(KeyCode.UpArrow))
            {
                GameObject o = Instantiate(shoot, transform.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
                if ((transform.GetComponentInParent<Rigidbody2D>() as Rigidbody2D) != null)
                {
                    o.rigidbody2D.velocity = (transform.GetComponentInParent<Rigidbody2D>() as Rigidbody2D).velocity + Vector2.right * 7;
                }
            }
            else
            {
                if (anim != null)
                    anim.SetTrigger("isShooting");
                GameObject o = Instantiate(shoot, transform.position, transform.rotation) as GameObject;
                if (transform.lossyScale.x < 0){
					o.transform.Rotate(Vector3.up,180f);
				}
                if ((transform.GetComponentInParent<Rigidbody2D>() as Rigidbody2D) != null)
                {
                    if (transform.lossyScale.x < 0)
                    {
                        o.rigidbody2D.velocity = (transform.GetComponentInParent<Rigidbody2D>() as Rigidbody2D).velocity - Vector2.right * 7;
                        //o.rigidbody2D.angularVelocity = (transform.GetComponentInParent<Rigidbody2D>() as Rigidbody2D).angularVelocity;
                    }
                    else
                    {
                        o.rigidbody2D.velocity = (transform.GetComponentInParent<Rigidbody2D>() as Rigidbody2D).velocity + Vector2.right * 7;
                        //o.rigidbody2D.angularVelocity = (transform.GetComponentInParent<Rigidbody2D>() as Rigidbody2D).angularVelocity;
                    }
                }
            }
            lastShotTime = Time.time;
            if(Ammo != -1)
                Ammo--;
        }
    }
}
