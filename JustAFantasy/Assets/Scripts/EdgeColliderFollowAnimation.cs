using UnityEngine;
using System.Collections;

public class EdgeColliderFollowAnimation : MonoBehaviour {

	SpriteRenderer sp;
	//BoxCollider2D bc;
	EdgeCollider2D ed;

	// Use this for initialization
	void Start () {
		sp=this.GetComponent<SpriteRenderer>() as SpriteRenderer;
		//bc=this.GetComponent<BoxCollider2D>() as BoxCollider2D;
		ed=this.GetComponent<EdgeCollider2D>() as EdgeCollider2D;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 spSize = sp.bounds.size;
		Vector3 edSize = ed.bounds.size;
		float xRatio = spSize.x / edSize.x;
		float yRatio = spSize.y / edSize.y;
		int n =ed.pointCount;
		Vector2[] newPoints = new Vector2[n];
		for (int i=0; i< ed.pointCount; i++){
			Debug.Log(ed.points[i]);
			float newX = ed.points[i].x*xRatio;
			float newY = ed.points[i].y*yRatio;
			Debug.Log(newX+" "+newY);
			newPoints[i]=new Vector2 (newX,newY);
			Debug.Log(ed.points[i] +" nuovo");
		}
		ed.points = newPoints;
	}
}
