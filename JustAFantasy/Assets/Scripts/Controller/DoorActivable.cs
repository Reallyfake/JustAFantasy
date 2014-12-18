using UnityEngine;
using System.Collections;

public class DoorActivable : MonoBehaviour {

	void Die(){
		Debug.Log ("attivato");
		Destroy (this.gameObject);
	}
}
