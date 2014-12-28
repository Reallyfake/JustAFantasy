using UnityEngine;
using System.Collections;

public class FishMover : MonoBehaviour {

	private Transform tf;
	private Vector2 initialpostion;
	public float maxOffset=10f;
	public float minOffset=10f;
	public float epsilon=0.1f;
	public float speed=10;
	public float initialTime;

	// Use this for initialization
	void Start () {
		tf = this.GetComponent<Transform>() as Transform;
		initialpostion = tf.position;	
	}
	
	// Update is called once per frame
	void Update () {
		tf.position=new Vector2 (tf.position.x, Mathf.PingPong((initialTime+Time.time)*speed*Time.deltaTime,maxOffset-minOffset)+minOffset+initialpostion.y);
		if (tf.position.y >= initialpostion.y+maxOffset-epsilon)
			tf.rotation = Quaternion.AngleAxis(180, Vector3.forward);
		if (tf.position.y <= initialpostion.y+minOffset+epsilon)
			tf.rotation = Quaternion.AngleAxis(0, Vector3.forward);
	}

	void OnTriggerEnter2D(Collider2D other){
		other.gameObject.SendMessage("SpikeHit", transform.position, SendMessageOptions.DontRequireReceiver);
	}
}
