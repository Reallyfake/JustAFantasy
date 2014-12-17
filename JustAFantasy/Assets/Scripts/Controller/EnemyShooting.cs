using UnityEngine;
using System.Collections;

public class EnemyShooting : jfEnemyController {

	// shot and it spawn position
	public GameObject shot;
	private Transform shotSpawn;

	// start and end of my sight line
	private Transform sightStart, sightEnd;

	// have i seen the player?
	private bool found = false;

	// patrol bounds
	public float xMin,xMax;

	// patrol speed
	public float speed;

	// used to have a fire ratio
	public float nextFire,fireRate;

	// what do I see?
	Collider2D hit;

	void Start(){
        shotSpawn = transform.GetChild(0).gameObject.transform;
        sightStart = transform.GetChild(1).gameObject.transform;
        sightEnd = transform.GetChild(2).gameObject.transform;
	}

	void Update () {

		// what am i seeing?
		hit=Physics2D.Linecast(sightStart.position, sightEnd.position).collider;

		//have I seen a player?
		if (hit!= null && hit.tag=="Player"){
			Attack();
		} else {
			Patrol ();
		}
	}

	void Patrol () {
		if (transform.localPosition.x > xMax || transform.localPosition.x < xMin){
			transform.Rotate(new Vector2(0,180));
			transform.Translate(Vector2.right*speed);
		} else {
			transform.Translate(Vector2.right*speed);
		}
	}

	void Attack(){
		if (Time.time> nextFire){
			nextFire= Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}


}
