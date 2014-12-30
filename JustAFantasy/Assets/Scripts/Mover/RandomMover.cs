using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour {

	private Transform tf;
	private Rigidbody2D rb;
	public float Xprobability=0.5f;
	public float Yprobability=0.5f;
	private float Xversus,Yversus;
	public float Xspeed=5f;
	public float Yspeed=5f;

	// Use this for initialization
	void Start () {
		tf= this.GetComponent<Transform>() as Transform;
		rb= this.GetComponent<Rigidbody2D>() as Rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {

		if (Random.Range(0f,1f) < Xprobability){
			Xversus = 1f;
		} else {
			Xversus = -1f;
		}

		if (Random.Range(0f,1f) < Yprobability){
			Yversus = 1f;
		} else {
			Yversus = -1f;
		}

		rb.velocity += Vector2.right*Xspeed*Time.deltaTime*Xversus;
		rb.velocity += Vector2.up*Yspeed*Time.deltaTime*Yversus;

		float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
		tf.rotation = Quaternion.AngleAxis(angle, Vector3.forward);



	
	}
}
