using UnityEngine;
using System.Collections;

public class EnemyFighter : MonoBehaviour {

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

	// attacking speed
	public float speedAttack;

	// what do I see?
	Collider2D hit;

	void Start(){
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
		//an animation will make the enemy seem to attack
		if (tf.position.x > xMax || tf.position.x < xMin){
			tf.Rotate(new Vector2(0,180));
			tf.Translate(Vector2.right*speedAttack);
		} else {
			tf.Translate(Vector2.right*speedAttack);
		}
	}


}
