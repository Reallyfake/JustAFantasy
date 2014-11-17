using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	// shot and it spawn position
	public GameObject shot;
	public Transform shotSpawn;

	// my transform
	public Transform tf;

	// start and end of my sight line
	public Transform sightStart, sightEnd;

	// have i seen the player?
	public bool found = false;

	// patrol bounds
	public float xMin,xMax;

	// patrol speed
	public float speed;

	// used to have a fire ratio
	public float nextFire,fireRate;

	// what do I see?
	Collider2D hit;

	void Start(){
		tf = GetComponent<Transform> () as Transform;
	}

	void Update () {

		// what am i seeing?
		hit=Physics2D.Linecast(sightStart.position, sightEnd.position).collider;

		//have I seen a player?
		if (hit!= null && hit.tag=="player"){
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
