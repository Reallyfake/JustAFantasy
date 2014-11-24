using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

	// death animation
	public GameObject explosion;

	// amount of health
	public int energy;

	// standard color of the object
	Color normal;

	// fire ratio
	public float nextTime,timeRate;

	// Use this for initialization
	void Start () {
		normal = this.GetComponent<SpriteRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {

		// if i have no energy, i die
		if (energy <= 0) {
			Destroy(gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}

		// restore normal color after been hit
		if (Time.time > nextTime){
			this.GetComponent<SpriteRenderer>().material.color = normal;
			nextTime = Time.time + timeRate;
		}
	
	}

	// public method called by shots hitting me
	public void Gotcha (int damage) {

		// flash red
		this.GetComponent<SpriteRenderer>().material.color = Color.red;

		// lose energy
		energy -= damage;
	}


}
