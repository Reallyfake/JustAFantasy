using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, yMin, yMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float force;
	Rigidbody2D rb = null;

	public Done_Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;

	void Start () {

		rb = GetComponent<Rigidbody2D> () as Rigidbody2D;
		
	}
	

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(Vector2.up*force, ForceMode2D.Impulse);
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.velocity = movement * speed;
		
		rb.position = new Vector2
		(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax) 
			
		);
	}
}
