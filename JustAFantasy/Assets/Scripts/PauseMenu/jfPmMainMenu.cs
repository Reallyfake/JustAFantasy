using UnityEngine;
using System.Collections;

public class jfPmMainMenu : MenuElement {

	void OnMouseUp(){
		Time.timeScale = 1;
		Application.LoadLevel ("MainMenu");
		}
}
