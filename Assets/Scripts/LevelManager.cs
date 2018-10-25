using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Vector2 startingPoint;
    public GameObject player;
    public GameObject endPoint;
    public GameObject key;
    public int currLevel = 1;
    private int reqKeys;

    public List<Vector2> keyPositions = new List<Vector2>();

	// Use this for initialization
	void Start () {
        spawnPlayer();
        spawnKeys();
        reqKeys = keyPositions.Count;
    }
	
	// Update is called once per frame
	void Update () {

        // Check if player dead
        if (!GameObject.FindWithTag("Player")) {
            spawnPlayer();
        }
	}

    private void spawnPlayer() {
        GameObject playerClone;
        playerClone = Instantiate(player, startingPoint, this.transform.rotation) as GameObject;
        playerClone.transform.SetParent(this.transform);
    }

    private void spawnKeys() {
        foreach (Vector2 pos in keyPositions)
        {
            GameObject keyClone;
            keyClone = Instantiate(key, pos, this.transform.rotation) as GameObject;
            keyClone.transform.SetParent(this.transform);
        }
    }

    public void changeLevel() {
        Debug.Log("Endpoint reached");
        string nextSceneName = "Level " + (currLevel + 1).ToString();
        SceneManager.LoadScene(nextSceneName);
    }

    public void keyPickup() {
        reqKeys--;
        Debug.Log(reqKeys);
    }


}
