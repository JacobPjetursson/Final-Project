using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject coin;
    private int currLevel;
    private int reqCoins;
    private int currEndpoints;
    private bool isDead;

    private List<Vector3> coinPositions = new List<Vector3>();
    private GameObject[] coins;
    private GameObject[] AIs;
    private GameObject[] players;
    private GameObject[] endPoints;
    private GameObject[] keys;
    private GameObject[] missiles;
    public GameObject UI;

    // Use this for initialization
    void Start () {
        string sceneName = SceneManager.GetActiveScene().name;
        currLevel = (int) char.GetNumericValue(sceneName[sceneName.Length - 1]);
        coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject c in coins)
        {
            coinPositions.Add(c.transform.position);
        }
        reqCoins = coins.Length;

        AIs = GameObject.FindGameObjectsWithTag("AIEnemy");
        players = GameObject.FindGameObjectsWithTag("Player");
        endPoints = GameObject.FindGameObjectsWithTag("Endpoint");
        keys = GameObject.FindGameObjectsWithTag("Key");
        missiles = GameObject.FindGameObjectsWithTag("Missile");
        currEndpoints = 0;

        UI.GetComponent<UIManager>().hidePaused(isDead);

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("escape") && !isDead){
            UI.GetComponent<UIManager>().pauseControl(isDead);
        }
	}

    public void playerDied() {
        isDead = true;
        UI.GetComponent<UIManager>().showPaused(isDead);
        Time.timeScale = 0;
    }

    public void restartLevel() {
        isDead = false;
        UI.GetComponent<UIManager>().hidePaused(isDead);
        Time.timeScale = 1;
        respawnAIs();
        respawnKeys();
        respawnMissiles();
        spawnCoins();
        respawnPlayers();
    }

    private void spawnCoins() {
        for (int i = 0; i < coins.Length; i++) {
            if (coins[i] == null) {
                GameObject coinClone;
                coinClone = Instantiate(coin, coinPositions[i], this.transform.rotation) as GameObject;
                coinClone.transform.SetParent(this.transform);
                coins[i] = coinClone;
            }
        }
        reqCoins = coins.Length;
    }

    private void respawnPlayers() {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerController>().kill();
        }
    }

    private void respawnKeys() {
        for (int i = 0; i < keys.Length; i++) {
            keys[i].GetComponent<KeyController>().respawn();
        }
    }

    private void respawnAIs() {
        for (int i = 0; i < AIs.Length; i++)
        {
            AIs[i].GetComponent<AStar.AStarEnemyController>().respawn();
        }
    }

    private void respawnMissiles() {
        for (int i = 0; i < missiles.Length; i++)
        {
            missiles[i].GetComponent<HomingEnemyController>().respawn();
        }
    }

    public void changeLevel() {
        string nextSceneName = "Level " + (currLevel + 1).ToString();
        if (Application.CanStreamedLevelBeLoaded(nextSceneName)) {
            GameSave.maxLevel = currLevel + 1;
            SceneManager.LoadScene(nextSceneName);
        } else {
            UI.GetComponent<UIManager>().endGame();
            Time.timeScale = 0;
        }
    }

    public void coinPickup() {
        reqCoins--;
    }

    public int getReqCoins() {
        return reqCoins;
    }

    public void enterEndpoint()
    {
        currEndpoints += 1;
        if (currEndpoints >= endPoints.Length) {
            changeLevel();
        }
    }

    public void exitEndpoint()
    {
        currEndpoints -= 1;
    }

}
