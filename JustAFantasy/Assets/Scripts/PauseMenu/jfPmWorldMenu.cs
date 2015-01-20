using UnityEngine;
using System.Collections;

public class jfPmWorldMenu : MenuElement {

	void OnMouseUp(){
		Time.timeScale = 1;
		Application.LoadLevel ("WorldMenu");
		}
}
