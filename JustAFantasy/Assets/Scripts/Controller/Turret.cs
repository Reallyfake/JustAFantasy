using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	// turret transform
	Transform tf;

	//target transform
	Transform target;

	//fire rate
	public float fireRate;

	float nextFire;

	// range of sight
	public float range;

	//what should i shoot?
	public GameObject shot;

	// shoot the shot from the eye and not from the center of the turret
	public float offset;


	// Use this for initialization
	void Start () {

		tf = GetComponent<Transform> () as Transform;
	
	}
	
	// Update is called once per frame
	void Update () {

		// find player position
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> () as Transform;
		Vector2 dir = target.position - tf.position;

		// calculate rotation of the turret to look at the target
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		tf.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Vector3 off = new Vector3 (dir.x,dir.y,0);
		off.Normalize();

		// if the target is in sight, shoot
		if (dir.magnitude < range && Time.time> nextFire){
			nextFire= Time.time + fireRate;
			Instantiate(shot, tf.position + off * offset, tf.rotation);
		}
	
	}
}
