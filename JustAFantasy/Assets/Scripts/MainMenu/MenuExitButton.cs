using UnityEngine;
using System.Collections;

public class MenuExitButton : MenuElement {

	void OnMouseUp(){
		Application.Quit ();
		}
}
