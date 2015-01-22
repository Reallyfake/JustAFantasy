using UnityEngine;
using System.Collections;

public class ChangeCameraSize : MonoBehaviour {
	
	public float xMin,xMax;
	float sizeCameraOr;
	public float sizeCamera;
	public float speed;
	float newIn;


	void Start () {
		sizeCameraOr = (this.GetComponent<Camera>() as Camera).orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > xMin && this.transform.position.x < xMax){
			newIn += speed*Time.deltaTime;
			newIn = Mathf.Clamp(newIn,sizeCameraOr,sizeCamera);
			(this.GetComponent<Camera>() as Camera).orthographicSize = newIn;

		}	else {
			newIn -= speed*Time.deltaTime;
			newIn = Mathf.Clamp(newIn,sizeCameraOr,sizeCamera);
			Debug.Log(newIn);
			(this.GetComponent<Camera>() as Camera).orthographicSize = newIn;

		}
	}
}
