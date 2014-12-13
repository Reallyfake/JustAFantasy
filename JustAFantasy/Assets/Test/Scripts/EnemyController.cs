using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Rigidbody2D rb = null;
	Transform tf = null;
	Rigidbody2D tarTf = null;
	public float xMin, xMax, speed;
	public float angle;

	public bool isRight,isLeft;
	public GameObject target;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> () as Rigidbody2D;
		tf = GetComponent<Transform> () as Transform;
		tarTf = target.GetComponent<Rigidbody2D> () as Rigidbody2D;
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D tg = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> () as Rigidbody2D;
		Vector2 v_diff = tarTf.position - tg.position;
		//Debug.Log ("Ciao");

		//Debug.Log (rb.position);
		//Debug.Log (tg.position);

		RaycastHit2D hit = Physics2D.Raycast(rb.position, v_diff , 100f, -1);

		if (isRight) {
						if (rb.position.x < xMax)
								rb.position += Vector2.right * speed;
						else {
								isRight = false;
								isLeft = true;
						}


				}
		else if (isLeft) {
						if (rb.position.x > xMin)
								rb.position += Vector2.right * (-speed);
						else {
								isRight = true;
								isLeft = false;
						}
				}
		if (hit.collider!=null && (hit.collider.tag == "Player" || hit.collider.tag=="Enemy") && Time.time > nextFire){
			float atan2 = Mathf.Atan2 ( v_diff.y, v_diff.x );
			Debug.Log ("Culo");
			Debug.Log (v_diff);
			Debug.Log(atan2 * Mathf.Rad2Deg);
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, Quaternion.Euler(0f, 0f, angle-(atan2 * Mathf.Rad2Deg)) );
			audio.Play ();
		}
	}
}
