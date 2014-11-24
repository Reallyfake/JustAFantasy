using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	// enemy Health component
	Energy enemyHealth;

	// damage of one shot
	public int damage;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "enemy") {
			Destroy(gameObject);
			enemyHealth = other.GetComponent<Energy>();
			if(enemyHealth != null){

				//call a method that cause damage to the enemy
				enemyHealth.Gotcha(damage);				
			}
		}
	}
}
