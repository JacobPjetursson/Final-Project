using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject coin;
    public int currLevel = 1;
    private int reqCoins;
    private int currEndpoints;

    private List<Vector3> coinPositions = new List<Vector3>();
    private GameObject[] coins;
    private GameObject[] AIs;
    private GameObject[] players;
    private GameObject[] endPoints;
    private GameObject[] keys;
    public GameObject UI;

    // Use this for initialization
    void Start () {
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
        currEndpoints = 0;

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void playerDied() {
        UI.GetComponent<UIManager>().showPaused();
        Time.timeScale = 0;
    }

    public void restartLevel() {
        UI.GetComponent<UIManager>().hidePaused();
        Time.timeScale = 1;
        respawnAIs();
        respawnKeys();
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

    public void changeLevel() {
        string nextSceneName = "Level " + (currLevel + 1).ToString();
        SceneManager.LoadScene(nextSceneName);
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
