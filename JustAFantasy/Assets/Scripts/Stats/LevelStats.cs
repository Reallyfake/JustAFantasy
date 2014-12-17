using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelStats {

	public string levelName;
	public bool unlocked;
	public int weaponFound;
	public int weaponTotal;
	public int secretFound;
	public int secretTotal;

	public LevelStats () {
		this.levelName = "";
		this.unlocked = false;
		this.weaponFound = 0;
		this.weaponTotal = 0;
		this.secretFound = 0;
		this.secretTotal = 0;
	}

	public LevelStats (string levelNameNew, bool unlockedNew, int weaponFoundNew, int weaponTotalNew, int secretFoundNew, int secretTotalNew) {
		this.levelName = levelNameNew;
		this.unlocked = unlockedNew ;
		this.weaponFound = weaponFoundNew;
		this.weaponTotal = weaponTotalNew;
		this.secretFound = secretFoundNew;
		this.secretTotal = secretTotalNew;
	}

}
