using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameStats {


	public int maxLifePoints;
	public ArrayList levelStatsList = new ArrayList();
	public bool[] weaponsUnlocked = new bool[8];

	//default constructor
	public GameStats () {
		this.maxLifePoints = 0;
		this.levelStatsList = new ArrayList();
		this.weaponsUnlocked = new bool[8];
	}

	//constructor
	public GameStats (int maxLifePointsNew, ArrayList levelStatsListNew, bool[] weaponsUnlockedNew) {
		this.maxLifePoints = maxLifePointsNew;
		this.levelStatsList = levelStatsListNew;
		this.weaponsUnlocked = weaponsUnlockedNew;
	}

	// create the statistics for a new game
	public static GameStats CreateNewGame() {

		//maxlife
		int life = 3;

		//levels
		ArrayList levels = new ArrayList();
		levels.Add(new LevelStats("1.Foodland",true,0,2,0,1));
		levels.Add(new LevelStats("2.Boh",false,0,3,0,2));
		levels.Add(new LevelStats("3.Mah",false,0,5,0,4));
		levels.Add(new LevelStats("4.Chilosa?",false,0,1,0,0));
		levels.Add(new LevelStats("5.Chissene",false,0,1,0,6));

		//weapons unlocked
		bool[] weapons = new bool[8];
		weapons[0] = true;
		for (int i=1;i<8;i++){
			weapons[i]=false;
		}

		GameStats gs = new GameStats(life,levels,weapons);
		return gs;
	}




}
