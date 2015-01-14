using UnityEngine;
using System.Collections;

public class SettingsQuality : MonoBehaviour {

	public int mode;
	
	void OnMouseUp(){
		QualitySettings.SetQualityLevel(mode);
	}
}
