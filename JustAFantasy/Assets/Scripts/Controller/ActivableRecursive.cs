using UnityEngine;
using System.Collections;

public class ActivableRecursive : MonoBehaviour {

	public static void SetActiveDavide(GameObject oggetto, bool active){
		oggetto.SetActive(active);
		foreach(Transform childTransform in oggetto.transform)
		{
			SetActiveDavide(childTransform.gameObject, active);
		}
	}

	//non può funzionare, vedremo se è sistemabile
	void Active(){
		SetActiveDavide(gameObject,true);
		gameObject.SetActive(true);
	}

	void DeActive(){
		SetActiveDavide(gameObject,false);
		gameObject.SetActive(true);
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
