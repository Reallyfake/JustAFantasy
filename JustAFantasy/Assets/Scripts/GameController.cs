using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameStats gs;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		gs = SaveLoad.Load();
	}
	
	void unlockLevel (int i){
		gs.levelUnlocked[i]=true;
	}
}
