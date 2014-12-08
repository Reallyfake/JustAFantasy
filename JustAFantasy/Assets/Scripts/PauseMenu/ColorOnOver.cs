using UnityEngine;
using System.Collections;

public class ColorOnOver : MonoBehaviour {

	void OnMouseEnter(){
				guiText.color = Color.red;
		}

	void OnMouseExit(){
				guiText.color = Color.white;
		}
}
