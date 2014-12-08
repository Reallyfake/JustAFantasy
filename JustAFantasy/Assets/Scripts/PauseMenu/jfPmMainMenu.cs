using UnityEngine;
using System.Collections;

public class jfPmMainMenu : MonoBehaviour {

	void OnMouseUp(){
		Time.timeScale = 1;
		Application.LoadLevel ("MainMenu");
		}
}
