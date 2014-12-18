using UnityEngine;
using System.Collections;

public class WorldMapNumber : MonoBehaviour {

	public string levelName;

	void OnMouseUp(){
		Application.LoadLevel(levelName);
	}

}
