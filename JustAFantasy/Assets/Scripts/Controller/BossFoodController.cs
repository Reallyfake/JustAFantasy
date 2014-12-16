using UnityEngine;
using System.Collections;

public class BossFoodController : jfEnemyController {


	//what should i ShotController and where?
	public GameObject shot;
	public Transform shotSpawn;

	// my transform
	public Transform tf;

	// fire ratio
	public float fireRate;

	// speed, x bounds
	public float speed,xMin,xMax;
	
	private float nextFire;

	// Use this for initialization
	void Start () {

		tf = GetComponent<Transform> () as Transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		// move horizaly between bounds
		tf.position=new Vector2 (Mathf.PingPong(Time.time * speed,xMax-xMin) +xMin , tf.position.y);

		// shoot every fire ratio time
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, Quaternion.AngleAxis(270f, Vector3.forward));
			audio.Play ();
		}
	
	}
}
