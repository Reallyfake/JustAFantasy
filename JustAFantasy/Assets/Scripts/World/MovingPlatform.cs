using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	Transform tf = null;
	
	public bool isMovingVertical = false;
	public bool isMovingHorizontal = false;
	public bool eventBased = false;
	public bool startMoving = false;
	public float speed = 2f;
	public float pingLength = 1f;
	public float pongTime = 3f;
	public float height = 0.01f;
	public float width = 0.01f;

	// Use this for initialization
	void Start () {
		tf = transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (eventBased == true) {
			//una variablie specifica x ogni elemento che si muove ad evento
			if (isMovingVertical == true && startMoving == true) {
				this.MovingVertical ();
			}
			if (isMovingHorizontal == true && startMoving == true) {
				this.MovingHorizontal ();
			}
		} else {
			if (isMovingVertical == true) {
				this.MovingVertical ();
			}
			if (isMovingHorizontal == true) {
				this.MovingHorizontal ();
			}
		}
	}

	void MovingVertical(){
		tf.position = tf.position + Vector3.Lerp(Vector3.down*height, Vector3.up*height ,
		                                         Mathf.PingPong(Time.time / pongTime, pingLength));
	}

	void MovingHorizontal(){
		tf.position = tf.position + Vector3.Lerp(Vector3.left*width, Vector3.right*width ,
		                                         Mathf.PingPong(Time.time / pongTime, pingLength));
	}
}
