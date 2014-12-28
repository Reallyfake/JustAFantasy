using UnityEngine;
using System.Collections;

public class SinMover : MonoBehaviour {

	public float intensity=1f;
	public float speed=1f;

	private Transform tf;
	private Vector2 initialpostion;
	public float maxOffset=10f;
	public float minOffset=-10f;
	public float epsilon=0.1f;
	public float speedX=10;
	public float initialTime;
	
	// Use this for initialization
	void Start () {
		tf = this.GetComponent<Transform>() as Transform;
		initialpostion = tf.position;	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Mathf.PingPong((initialTime+Time.time)*speedX,maxOffset-minOffset)+minOffset+initialpostion.x + " e poi " +  (initialpostion.y + Mathf.Sin((initialTime+Time.time)*speed)*intensity));
		tf.position=new Vector2 (Mathf.PingPong((initialTime+Time.time)*speedX,maxOffset-minOffset)+minOffset+initialpostion.x , (initialpostion.y + Mathf.Sin(initialTime+Time.time*speed)*intensity));
		if (tf.position.x >= initialpostion.x+maxOffset-epsilon)
			tf.rotation = Quaternion.AngleAxis(180, Vector3.up);
		if (tf.position.x <= initialpostion.x+minOffset+epsilon)
			tf.rotation = Quaternion.AngleAxis(0, Vector3.up);
	}
}
