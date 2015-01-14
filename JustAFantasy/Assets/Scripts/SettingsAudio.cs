using UnityEngine;
using System.Collections;

public class SettingsAudio : MonoBehaviour {

	public int mode;

	void OnMouseUp(){
		switch (mode){
		case 1 : AudioSettings.speakerMode = AudioSpeakerMode.Mono;
			break;
		case 2 : AudioSettings.speakerMode = AudioSpeakerMode.Stereo;
			break;
		case 3 : AudioSettings.speakerMode = AudioSpeakerMode.Quad;
			break;
		default : AudioSettings.speakerMode = AudioSpeakerMode.Surround;
			break;
		}
		if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>() != null){
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Play();
		}
	}
}
