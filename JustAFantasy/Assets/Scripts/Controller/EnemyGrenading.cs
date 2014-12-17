using UnityEngine;
using System.Collections;

public class EnemyGrenading : jfEnemyController {

	// shot and it spawn position
	public GameObject shot;
	private Transform shotSpawn;

	// my transform
	private Transform tf;

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
		tf = GetComponent<Transform> () as Transform;
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
		if (tf.position.x > xMax || tf.position.x < xMin){
			tf.Rotate(new Vector2(0,180));
			tf.Translate(Vector2.right*speed);
		} else {
			tf.Translate(Vector2.right*speed);
		}
	}

	void Attack(){
		if (Time.time> nextFire){
			nextFire= Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}


}
