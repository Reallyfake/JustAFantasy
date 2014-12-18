using UnityEngine;
using System.Collections;

public class MenuBackButton : MonoBehaviour {

	public GameObject cube;
	
	void OnMouseUp(){
		StartCoroutine (Rotate());
	}
	
	IEnumerator Rotate() {
        float step = 270f - cube.transform.eulerAngles.y;
        if (step > 180f)
            step -= 360f;
        step /= 90f;

        for (int f = 0; f < 90; f++) {
			cube.transform.Rotate(0f,step,0f);
			yield return new WaitForSeconds(.005f);
		}
	}
}
