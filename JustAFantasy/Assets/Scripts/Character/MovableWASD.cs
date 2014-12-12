using UnityEngine;
using System.Collections;

public class MovableWASD : MonoBehaviour {

	public float speed = 50f;
	public float maxSpeed = 8f;
	public float jumpHeight = 2.7f;
	private Rigidbody2D rb;
	private bool canJump = false;

	public void allowJump(){
				canJump = true;
		}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> () as Rigidbody2D;
	}

	bool isForward(){
		return Input.GetKey (KeyCode.RightArrow);
		}

	bool isBackward(){
		return Input.GetKey (KeyCode.LeftArrow);
	}

	bool isJump(){
		return Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.Space);
	}

	// Update is called once per frame
	void Update () {
		if (isForward ()) {
						rb.velocity = new Vector2 (maxSpeed, rb.velocity.y);
				} else {
						if (isBackward ()) {
								rb.velocity = new Vector2 (-maxSpeed, rb.velocity.y);
						}else
			{
				if(!isForward() && ! isBackward()){
					rb.velocity =  new Vector2(0,rb.velocity.y);
				}
			}
				}
		if (isJump () && canJump) {
			rb.AddForce (transform.up * jumpHeight * 10, ForceMode2D.Impulse);
			canJump = false;
		}
	}
}
