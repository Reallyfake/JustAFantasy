using UnityEngine;
using System.Collections;

public class jfPmWorldMenu : MonoBehaviour {

	void OnMouseUp(){
		Time.timeScale = 1;
		Application.LoadLevel ("WorldMenu");
		}
}
