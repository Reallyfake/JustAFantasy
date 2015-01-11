using UnityEngine;
using System.Collections;

public class AudioCameraController : MonoBehaviour {

	AudioSource[] a;

	void Start () {
		a = this.GetComponents<AudioSource>() as AudioSource[];
	}
	
	// Update is called once per frame
	void ChangeAudio () {
		a[0].Stop();
		a[1].Play();
	}
}
