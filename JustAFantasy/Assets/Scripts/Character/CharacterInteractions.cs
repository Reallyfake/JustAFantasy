using UnityEngine;
using System.Collections;

public class CharacterInteractions : MonoBehaviour {

	public float lastHitTime;
	public float hitRatio;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("EnemyFire"))
        {
            int dmg = (other.gameObject.GetComponent<ShotController>() as ShotController).damage;
            Destroy(other.gameObject);
            if (transform.parent != null)
                transform.parent.SendMessage("OnPlayerHit", dmg, SendMessageOptions.DontRequireReceiver);
        }

		if (other.gameObject.tag.Equals("Spike"))
		{
			Vector2 dir = -(other.transform.position - transform.position);
			Rigidbody2D rb= this.GetComponent<Rigidbody2D>() as Rigidbody2D;
			rb.AddForce(dir*5f,ForceMode2D.Impulse);
			if (transform.parent != null){
				lastHitTime = Time.time + hitRatio;
				transform.parent.SendMessage("OnPlayerHit", 1, SendMessageOptions.DontRequireReceiver);
			}
		}
    }

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("Spike"))
		{
			if (transform.parent != null && Time.time > lastHitTime){
				lastHitTime = Time.time + hitRatio;
				transform.parent.SendMessage("OnPlayerHit", 1, SendMessageOptions.DontRequireReceiver);
			}
		}
	}


    void Shoot()
    {
        if (transform.GetChild(1) != null && transform.GetChild(1).gameObject.GetComponent<jfWeapon>() != null)
            transform.GetChild(1).gameObject.SendMessage("Shoot");
    }

    void ChangeWeapon(GameObject w)
    {
        if (transform.GetChild(1) != null && transform.GetChild(1).gameObject.GetComponent<jfWeapon>() != null)
        {
            w.transform.position = transform.GetChild(1).gameObject.transform.position;
            w.transform.rotation = transform.GetChild(1).gameObject.transform.rotation;
            if (transform.lossyScale.x * w.transform.lossyScale.x < 0)
            {
                Vector3 scale = w.transform.localScale;
                scale.x *= -1;
                w.transform.localScale = scale;
            }

            w.renderer.enabled = true;
            transform.GetChild(1).gameObject.renderer.enabled = false;
            transform.GetChild(1).gameObject.transform.parent = w.transform.parent;
            w.transform.parent = transform;
            
        }
        if (transform.parent != null)
            transform.parent.SendMessage("WeaponChanged", w, SendMessageOptions.DontRequireReceiver);
    }
}
