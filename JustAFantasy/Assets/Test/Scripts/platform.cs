using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {

	Transform tf = null;
	public float speed;
	public int tiles;
	public float size=1.28f;
	public float xlimit;
	public bool moving;

	// Use this for initialization
	void Start () {
		tf = transform;
		xlimit = -2 * size;
	}
	
	// Update is called once per frame
	void Update () {
		float shift = 0f;
		if (tf.position.x < xlimit)
						shift = tiles * size;
		tf.position = transform.position + Vector3.left * speed * Time.deltaTime + Vector3.right*shift;
		if (moving)
						tf.position = tf.position + Vector3.Lerp (Vector3.down * .01f, Vector3.up * .01f, Mathf.PingPong (Time.time/2f,1)); 
	}
}
