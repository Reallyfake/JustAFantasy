using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameStatsTest{

	public int intero;
	public bool booleano;
	public float velocità;

	public GameStatsTest () {
		intero=0;
		booleano = false;
		velocità = 0.0f;
	}

	public GameStatsTest (int i,bool b, float f) {
		intero=i;
		booleano = b;
		velocità = f;
	}
}
