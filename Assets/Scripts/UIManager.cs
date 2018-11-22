﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject deathScreen;
    public GameObject pauseScreen;

	void Start () {
        deathScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown("escape") && !deathScreen.activeSelf)
        {
            pauseControl();
        }
    }

	public void showDeathScreen(bool show){
        deathScreen.SetActive(show);
    }

	public void showPauseScreen(bool show){

        pauseScreen.SetActive(show);
    }

	public void pauseControl(){
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPauseScreen(true);
        } else if (Time.timeScale == 0){
            Time.timeScale = 1;
            showPauseScreen(false);
        }
    }

	public void loadMenu() { 
		SceneManager.LoadScene("Menu");
	}

    public void endGame() {
        // TODO - end game stuff
    }
}