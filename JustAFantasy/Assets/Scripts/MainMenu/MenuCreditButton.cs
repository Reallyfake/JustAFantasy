using UnityEngine;
using System.Collections;

public class MenuCreditButton : MenuElement {

	public GameObject cube;
	private bool isRunningCoroutine=false;
	
	void OnMouseUp(){
		if (!isRunningCoroutine){
			StartCoroutine (Rotate());
			isRunningCoroutine=true;
		}
	}
	
	IEnumerator Rotate() {
		float step = 180f - cube.transform.eulerAngles.y;
		if (step > 180f)
			step -= 360f;
		step /= 90f;
		
		for (int f = 0; f < 90; f++) {
			cube.transform.Rotate(0f,step,0f);
			yield return new WaitForSeconds(.005f);
		}
		isRunningCoroutine = false;
	}
}
