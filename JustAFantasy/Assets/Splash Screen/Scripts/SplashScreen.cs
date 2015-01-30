using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	float secs = 2f;				// number of seconds to wait

	public GameObject	splash;		// splash screen that is not shown in pro
	public GameObject	pgc;		// polimi game collective splash

	public string next_scene = string.Empty;

	// Use this for initialization
	void Start () {
		StartCoroutine (ShowSplashScreens ());
	}
	
	IEnumerator ShowSplashScreens()
	{


		yield return new WaitForSeconds(secs);
		splash.SetActive(false);

		yield return new WaitForSeconds(secs);
	
		Application.LoadLevel(next_scene);
	}
}
