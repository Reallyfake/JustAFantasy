using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Rigidbody2D rb = null;
	Transform tf = null;
	public float xMin, xMax, speed;

	public bool isRight,isLeft;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> () as Rigidbody2D;
		tf = GetComponent<Transform> () as Transform;
	
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
