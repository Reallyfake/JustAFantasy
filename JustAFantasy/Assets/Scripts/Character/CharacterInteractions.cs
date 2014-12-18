using UnityEngine;
using System.Collections;

public class CharacterInteractions : MonoBehaviour {

	public float hitRatio;

    void Die()
    {
        if (transform.parent != null)
            transform.parent.gameObject.SendMessage("IsDead", SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("EnemyFire"))
        {
            int dmg = (other.gameObject.GetComponent<ShotController>() as ShotController).damage;
            Destroy(other.gameObject);
            if (transform.parent != null)
                transform.parent.SendMessage("OnPlayerHit", dmg, SendMessageOptions.DontRequireReceiver);
        }
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("Spike"))
		{
			if (transform.parent){
				transform.parent.SendMessage("OnPlayerHit", 1, SendMessageOptions.DontRequireReceiver);
                gameObject.SendMessage("SpikeHit", other.transform.position, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

    void lootItem(string Effect)
    {
        if (transform.parent != null)
        {
            transform.parent.SendMessage("exeCommand", Effect, SendMessageOptions.DontRequireReceiver);
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
