using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameStats {
	
	public bool[] levelUnlocked = new bool[4];

	//default constructor
	public GameStats () {
		this.levelUnlocked = new bool[4];
	}

	//constructor
	public GameStats (bool[] levelUnlockedNew) {
		this.levelUnlocked = levelUnlockedNew;
	}

	// create the statistics for a new game
	public static GameStats CreateNewGame() {

		bool[] levels = new bool[4];
		levels[0] = true;
		for (int i=1;i<4;i++){
			levels[i]=false;
		}

		GameStats gs = new GameStats(levels);
		return gs;
	}




}
