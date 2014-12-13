using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	// enemy Health component
	Energy enemyHealth;

	// damage of one shot
	public int damage;
    public float lifeTime = 10f;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") {
			Destroy(gameObject);
			enemyHealth = other.GetComponent<Energy>();
			if(enemyHealth != null){

				//call a method that cause damage to the enemy
				enemyHealth.Gotcha(damage);				
			}
		}
	}

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            Destroy(gameObject);
    }
}
