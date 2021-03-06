﻿using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public GameObject explosion;
	// enemy Health component
	Energy enemyHealth;

	// damage of one shot
	public int damage;
    public float lifeTime = 10f;

	//should the shot remain in the scene?
	public bool resist;
    
	void OnTriggerEnter2D (Collider2D other)
	{
        
		if (other.tag == "Floor" && !resist) {
			Destroy(gameObject);
		}
	}
    
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            Destroy(gameObject);
    }

	void OnDestroy() {
		if (explosion != null)
			Instantiate(explosion,transform.position, transform.rotation);
	}
}
