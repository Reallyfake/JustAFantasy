using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {
			
	//it's static so we can call it from anywhere
	public static void Save(GameStats gs) {
		//SaveLoad.savedGames.Add(GameStatsTest.current);
		Debug.Log(Application.persistentDataPath);
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.banana"); //you can call it anything you want
		bf.Serialize(file, gs);
		file.Close();
	}	
	
	public static GameStats Load() {
		GameStats gs = new GameStats();
		if(File.Exists(Application.persistentDataPath + "/savedGames.banana")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.banana", FileMode.Open);
			gs = (GameStats)bf.Deserialize(file);
			file.Close();
		}
		return gs;
	}
}
