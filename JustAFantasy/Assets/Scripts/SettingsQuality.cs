using UnityEngine;
using System.Collections;

public class SettingsQuality : MenuElement {

	public int mode;
	
	void OnMouseUp(){
		QualitySettings.SetQualityLevel(mode);
	}
}
