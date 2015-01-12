using UnityEngine;
using System.Collections;

public class SlideObject : MonoBehaviour {

	public Vector2 direction;

	// Use this for initialization
	void onActive(){
		transform.Translate (direction);
		}
}
