using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour {

	GameObject myPlayer, myCamera;
	public GameObject[] targets;
	public float cameraRatio = 2f;

	// Use this for initialization
	void Start () {
		myPlayer=GameObject.FindGameObjectWithTag("Player");
		myCamera=GameObject.FindGameObjectWithTag("MainCamera");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			//change = true;
			StartCoroutine(changeCameraReally());
			if ((GetComponent<CircleCollider2D>() as CircleCollider2D) != null)
				(GetComponent<CircleCollider2D>() as CircleCollider2D).enabled = false;
			if ((GetComponent<BoxCollider2D>() as BoxCollider2D) != null)
				(GetComponent<BoxCollider2D>() as BoxCollider2D).enabled = false;
			if ((GetComponent<PolygonCollider2D>() as PolygonCollider2D) != null)
				(GetComponent<PolygonCollider2D>() as PolygonCollider2D).enabled = false;
			if ((GetComponent<EdgeCollider2D>() as EdgeCollider2D) != null)
				(GetComponent<EdgeCollider2D>() as EdgeCollider2D).enabled = false;
		}
	}
	
	IEnumerator changeCameraReally(){
		(myPlayer.GetComponent<MovableWASD>() as MovableWASD).BlockMovements();
		for (int i=0; i < targets.Length ;i++){
			if (targets[i] != null){
				(myCamera.GetComponent<FollowPlayer>() as FollowPlayer).follower = targets[i];
			}
			yield return new WaitForSeconds (cameraRatio);
			
		}
		(myCamera.GetComponent<FollowPlayer>() as FollowPlayer).follower = myPlayer;
		(myPlayer.GetComponent<MovableWASD>() as MovableWASD).FreeMovements();
	}
}
