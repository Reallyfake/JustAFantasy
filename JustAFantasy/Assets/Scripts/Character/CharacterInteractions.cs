using UnityEngine;
using System.Collections;

public class CharacterInteractions : MonoBehaviour {

	public float hitRatio;
    public WeaponsController Weapons;

    void Die()
    {
        CharacterStats cs = GetComponent<CharacterStats>() as CharacterStats;
        if (cs != null)
        {
            cs.SendMessage("RemoveLife", cs.LifePoints);
        }
    }

    void DieFast()
    {
        if (transform.parent != null)
            transform.parent.SendMessage("isDead", SendMessageOptions.DontRequireReceiver);
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
        Weapons.shoot();
    }

    void ChangeWeapon(GameObject w)
    {
        if (transform.parent != null)
            transform.parent.SendMessage("WeaponChanged", w, SendMessageOptions.DontRequireReceiver);
    }
}
