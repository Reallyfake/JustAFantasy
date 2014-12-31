using UnityEngine;
using System.Collections;

public class Activable : MonoBehaviour {

	//non può funzionare, vedremo se è sistemabile
	void Active(){
		this.gameObject.SetActive(true);
		Debug.Log ("Attivo");
	}

	void DeActive(){
		this.gameObject.SetActive(false);
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
