using UnityEngine;
using System.Collections;

public class MenuBackButton : MonoBehaviour {

	public GameObject cube;
	
	void OnMouseUp(){
		StartCoroutine (Rotate());
	}
	
	IEnumerator Rotate() {
		for (int f = 0; f < 55; f++) {
			cube.transform.Rotate(0f,-1f,0f);
			yield return new WaitForSeconds(.03f);
		}
	}
}
