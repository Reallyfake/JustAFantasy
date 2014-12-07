using UnityEngine;
using System.Collections;

public class OnMouseColor : MonoBehaviour {

	void OnMouseEnter() {
		renderer.material.color = Color.red;
	}

	void OnMouseExit() {
		renderer.material.color = Color.white;
	}
}
