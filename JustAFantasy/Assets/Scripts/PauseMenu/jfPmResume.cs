using UnityEngine;
using System.Collections;

public class jfPmResume : MonoBehaviour {

	void OnMouseUp(){
		gameObject.transform.parent.gameObject.SetActive (false);
		Time.timeScale = 1;
	}
}
