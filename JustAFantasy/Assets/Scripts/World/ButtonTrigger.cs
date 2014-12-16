using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	Transform tf = null;
	public GameObject movingElement;
//	public float newPositionX = 5f;
	public float newPosiitonY = -3f;
	public float newPositionZ = 1f;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> () as Transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//scompare nel terreno
			tf.position = new Vector3(tf.position.x, newPosiitonY, newPositionZ);
			//modifico variabile x attivare evento
			if(movingElement.GetComponent<Smashing>().startMoving == false){
				SmashingTrigger();
			}
			if(movingElement.GetComponent<MovingPlatform>().startMoving == false){
				MovingTrigger();
			}
		}
	}

	void SmashingTrigger(){
		movingElement.GetComponent<Smashing>().startMoving = true;
	}

	void MovingTrigger(){
		movingElement.GetComponent<MovingPlatform> ().startMoving = true;
	}
}
