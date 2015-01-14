using UnityEngine;
using System.Collections;

public class RotatingAll : MonoBehaviour {

	Transform tf;
	public float speed;

	// Use this for initialization
	void Start () {
		tf = this.GetComponent<Transform>() as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		tf.Rotate(Vector3.forward,speed*Time.deltaTime);	
	}
}
