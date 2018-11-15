using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private Vector2 startingPoint;
    public GameObject player;
    public GameObject endPoint;
    public GameObject coin;
    public GameObject ai;
    public int currLevel = 1;
    private int reqCoins;

    private List<Vector3> coinPositions = new List<Vector3>();
    private List<Vector3> aiPositions = new List<Vector3>();
    private GameObject[] coins;
    private GameObject[] AIs;

    // Use this for initialization
    void Start () {
        startingPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
        coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject c in coins)
        {
            coinPositions.Add(c.transform.position);
        }
        reqCoins = coins.Length;

        AIs = GameObject.FindGameObjectsWithTag("AIEnemy");
        foreach (GameObject a in AIs)
        {
            aiPositions.Add(a.transform.position);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void restartLevel() {
        spawnAIs();
        spawnPlayer();
        spawnCoins();
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

    private void spawnPlayer() {
        GameObject playerClone;
        playerClone = Instantiate(player, startingPoint, this.transform.rotation) as GameObject;
        playerClone.transform.SetParent(this.transform);
    }

    private void spawnAIs() {
        for (int i = 0; i < AIs.Length; i++)
        {

            if (AIs[i] != null) {
                Destroy(AIs[i]);
            }
            GameObject aiClone;
            aiClone = Instantiate(ai, aiPositions[i], this.transform.rotation) as GameObject;
            aiClone.transform.SetParent(this.transform);
            AIs[i] = aiClone;

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

}
