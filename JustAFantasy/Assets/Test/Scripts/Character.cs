using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	Rigidbody2D rb = null;
	Transform tf = null;
	Animator an=null;
	bool AmJumping = false;

	public float force;

	// Use this for initialization
	void Start () {

		tf = GetComponent<Transform> () as Transform;
		rb = GetComponent<Rigidbody2D> () as Rigidbody2D;
		an= GetComponent<Animator> () as Animator;
	 
	}
	
	// Update is called once per frame
	void Update () {

		if (!AmJumping && Input.GetKeyDown (KeyCode.Space)){
			rb.AddForce(Vector3.up*force, ForceMode2D.Impulse);
			AmJumping = true;
			an.SetBool("isJumping",true);
		}
	
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		AmJumping = false;
		an.SetBool("isJumping",false);
	}
}
