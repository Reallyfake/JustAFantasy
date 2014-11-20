using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject follower;
	public float speed = 2f;
	public Vector2 offset = new Vector2(0,0);
	public float tollerance = 0.5f;

	void Update(){
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 tar = new Vector2 (follower.transform.position.x, follower.transform.position.y);
		if(Vector2.Distance(pos-offset, tar)>tollerance)
		{
			transform.position = new Vector3(transform.position.x + (follower.transform.position.x-(transform.position.x-offset.x))*speed*Time.deltaTime,
			                                 transform.position.y + (follower.transform.position.y-(transform.position.y-offset.y))*speed*Time.deltaTime,
			                                 transform.position.z);
		}
	}

}
