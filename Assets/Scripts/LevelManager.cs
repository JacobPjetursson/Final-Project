using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private int currLevel;
    private int reqCoins;
    private int reqEndpoints;
    private bool pickedupStar;

    private GameObject[] endPoints;
    public GameObject UI;

    void Start () {
        string sceneName = SceneManager.GetActiveScene().name;
        currLevel = (int) char.GetNumericValue(sceneName[sceneName.Length - 1]);
        reqCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        reqEndpoints = GameObject.FindGameObjectsWithTag("Endpoint").Length;
    }
	
	void Update () {
	}

    public void playerDied() {
        GameManager.deaths++;
        UI.GetComponent<UIManager>().showDeathScreen(true);
        Time.timeScale = 0;
    }

    public void restartLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void changeLevel() {
        string nextSceneName = "Level " + (currLevel + 1).ToString();
        if (Application.CanStreamedLevelBeLoaded(nextSceneName)) {
            if ((currLevel + 1) > GameManager.maxLevel)
                GameManager.maxLevel = currLevel + 1;
            GameManager.stars[currLevel] = pickedupStar;
            GameManager.SaveGame();
            SceneManager.LoadScene(nextSceneName);
        } else {
            UI.GetComponent<UIManager>().endGame();
        }
    }

    public void coinPickup() {
        reqCoins--;
    }

    public void starPickup() {
        pickedupStar = true;
    }

    public int getReqCoins() {
        return reqCoins;
    }

    public void enterEndpoint()
    {
        reqEndpoints--;
        if (reqEndpoints == 0) {
            changeLevel();
        }
    }

    public void exitEndpoint()
    {
        reqEndpoints++;
    }

}
