using UnityEngine;
using System.Collections;

public class Smashing : MonoBehaviour {

	Transform tf = null;

	public GameObject explosion;

	public bool isMoving = false;
	public bool eventBased = false;
	public bool startMoving = false;
	public float initialPos = 2f;
	public float speedDown = 4f;
	public float speedUp = 2f;
	public float nextUp, nextDown;

	private bool earthLevel = false;

	
	// Use this for initialization
	void Start () {
		tf = transform;
//		tf.position.y = initialPos;
	}
	
	// Update is called once per frame
	void Update () {
		//check su avriablie globale modificata da collisione con player
		if (eventBased == true) {
			if (isMoving == true && startMoving == true) {
				SmashingIt ();
			}
		} else {
			if (isMoving == true) {
				SmashingIt ();
			}
		}

//		tf.position = new Vector2 (tf.position.x, initialPos);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "player") {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
		}
		else{ //collisione col terreno
			nextUp= Time.time + nextDown; 
			earthLevel = true;
		}
//	new Vector2 (tf.position.x, initialPos);
	}

	void SmashingIt(){
		if (!earthLevel){
			tf.position = tf.position + Vector3.down*speedDown*Time.deltaTime;
		} 
		else{
			if (Time.time > nextUp){
				tf.position = tf.position + Vector3.up*speedUp*Time.deltaTime;
				if(tf.position.y > initialPos){
					earthLevel = false;
				}
			}
		}
	}

}
