using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Button menuButton;
	public Button restartButton;
	public GameObject pauseText;
	public GameObject fade;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void showPaused(bool isDead){
		if(isDead) {
			restartButton.GetComponentInChildren<Text>().text = "Respawn";
			pauseText.GetComponent<Text>().text = "You died...";
		}
		else if(!isDead) {
			restartButton.GetComponentInChildren<Text>().text = "Restart";
			pauseText.GetComponent<Text>().text = "Paused";
		}
		menuButton.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
		pauseText.SetActive(true);
		fade.SetActive(true);
 
    }

	public void hidePaused(bool isDead){
		Time.timeScale = 1;
        menuButton.gameObject.SetActive(false);
		restartButton.gameObject.SetActive(false);
		pauseText.SetActive(false);
		fade.SetActive(false);
    }

	public void pauseControl(bool isDead){
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused(isDead);
        } else if (Time.timeScale == 0){
            Time.timeScale = 1;
            hidePaused(isDead);
        }
    }

	public void loadMenu() { 
		SceneManager.LoadScene("Menu");
	}

    public void endGame() {
        // TODO - end game stuff
    }
}
