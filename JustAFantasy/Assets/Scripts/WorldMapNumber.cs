using UnityEngine;
using System.Collections;

public class WorldMapNumber : MenuElement {

	public string levelName;

	void OnMouseUp(){
		Application.LoadLevel(levelName);
	}

}
