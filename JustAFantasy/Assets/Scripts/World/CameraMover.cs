using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	Transform tf = null;
	public GameObject character;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> () as Transform;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 camera = new Vector3 (character.transform.position.x, character.transform.position.y, -10f);
		tf.position = camera;

	}
}
