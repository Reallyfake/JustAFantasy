﻿using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

    public GUITexture gameOver;
    public GUITexture levelClear;
    public GameObject NextLevel, MainMenu, WorldMenu;

	// Use this for initialization
	void Start () {
        NextLevel.SetActive(false);
        MainMenu.SetActive(false);
        WorldMenu.SetActive(false);
        gameOver.gameObject.SetActive(false);
        levelClear.gameObject.SetActive(false);
	}

    void GameOver()
    {
        StartCoroutine(crGameOver(3));
    }

    void StageClear()
    {
		(this.GetComponent<AudioSource>() as AudioSource).Play();
        StartCoroutine(crStageClear(3));
    }

    IEnumerator crStageClear(int s)
    {
        levelClear.gameObject.SetActive(true);
        Color32 baseColor = levelClear.color;
        for (int i = 0; i < s * 30; i++)
        {
            int alpha = Mathf.RoundToInt(255 * i / (s * 30));
            levelClear.color = new Color32(baseColor.r, baseColor.g, baseColor.b, (byte)alpha);
            yield return new WaitForSeconds(0.03f);
        }
        NextLevel.SetActive(true);
        MainMenu.SetActive(true);
        WorldMenu.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    IEnumerator crGameOver(int s)
    {
        gameOver.gameObject.SetActive(true);
        Color32 baseColor = gameOver.color;
        for (int i = 0; i < s * 30; i++)
        {
            int alpha = Mathf.RoundToInt(255 * i / (s * 30));
            gameOver.color = new Color32(baseColor.r, baseColor.g, baseColor.b, (byte)alpha);
            yield return new WaitForSeconds(0.03f);
        }
        NextLevel.SetActive(false);
        MainMenu.SetActive(true);
        WorldMenu.SetActive(true);
        levelClear.gameObject.SetActive(false);
    }

}