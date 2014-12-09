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

	void capSpeed(){
		if (rb.velocity.x > maxSpeed)
						rb.velocity = new Vector2 (maxSpeed, rb.velocity.y);
		if (rb.velocity.x < -maxSpeed)
						rb.velocity = new Vector2 (-maxSpeed, rb.velocity.y);
		}
	
	// Update is called once per frame
	void Update () {
		if (isForward ()) {
			rb.AddForce (transform.right * speed * Time.deltaTime * 100f, ForceMode2D.Force);
				}
		if (isBackward ()) {
			rb.AddForce (transform.right * (-speed) * Time.deltaTime * 100f, ForceMode2D.Force);
				}
		if (isJump () && canJump) {
			rb.AddForce (transform.up * jumpHeight * 10, ForceMode2D.Impulse);
			canJump = false;
		}
		capSpeed ();
	}
}
