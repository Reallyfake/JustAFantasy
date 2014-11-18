using UnityEngine;
using System.Collections;

public class FollowPoints : MonoBehaviour {

	private Vector2[] points;
	private float dTime;
	public float speed = 1f;
	private bool done = false;
	public float tightness = 1f;

	// Use this for initialization
	void Start () {
		points = new Vector2[5];
		points [0] = new Vector2 (0, 0);
		points [1] = new Vector2 (1, 0);
		points [2] = new Vector2 (2, 1);
		points [3] = new Vector2 (3, 3);
		points [4] = new Vector2 (3, 5);
		dTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (done)
						return;

		int pSize = points.Length;
		if (pSize == 0)
						return;
		if (pSize == 1) {
						transform.position = points [0];
						return;
				}
		dTime += Time.deltaTime;
		float dt = dTime * speed;
		float u = dt - Mathf.Floor (dt);
		int idx = (int)Mathf.Floor (dt) % pSize;
		Vector3 p0 = new Vector3(points[Mathf.Clamp(idx-1, 0, pSize-1)].x, points[Mathf.Clamp(idx-1, 0, pSize-1)].y, transform.position.z);
		Vector3 p1 = new Vector3(points[Mathf.Clamp(idx+0, 0, pSize-1)].x, points[Mathf.Clamp(idx+0, 0, pSize-1)].y, transform.position.z);
		Vector3 p2 = new Vector3(points[Mathf.Clamp(idx+1, 0, pSize-1)].x, points[Mathf.Clamp(idx+1, 0, pSize-1)].y, transform.position.z);
		Vector3 p3 = new Vector3(points[Mathf.Clamp(idx+2, 0, pSize-1)].x, points[Mathf.Clamp(idx+2, 0, pSize-1)].y, transform.position.z);

		if (idx == pSize - 1)
						done = true;

		float h1 = 2.0f * u * u * u - 3.0f * u * u + 1.0f;
		float h2 = -2.0f * u * u * u + 3.0f * u * u;
		float h3 = u * u * u - 2.0f * u * u + u;
		float h4 = u * u * u - u * u;

		Vector3 t1 = (p2 - p0) * tightness;
		Vector3 t2 = (p3 - p1) * tightness;
		if (idx > pSize - 3) {
						//forse controllo
			float distance = Vector3.Distance(transform.position, points[pSize-1]);
			if(distance>3f)
				transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Quaternion.LookRotation(p1 * h1 + p2 * h2 + t1 * h3 + t2 * h4).z, transform.rotation.w);
				} else {
			transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Quaternion.LookRotation(p1 * h1 + p2 * h2 + t1 * h3 + t2 * h4).z, transform.rotation.w);
				}
		transform.position = p1 * h1 + p2 * h2 + t1 * h3 + t2 * h4 ;
	
	}
}
