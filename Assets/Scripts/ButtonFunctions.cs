﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	private GameObject shooter;

    public void nextLevel()
    {
        GameManager.instance.ResetProjectiles();
        GameManager.instance.projectiles[GameManager.instance.getActive()].gameObject.SetActive(true);
        SoundManager.instance.PlayBattleMusic();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void restart()
    {
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("Death").SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
    }
}
