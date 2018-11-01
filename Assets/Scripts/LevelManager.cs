using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private Vector2 startingPoint;
    public GameObject player;
    public GameObject endPoint;
    public GameObject key;
    public GameObject projectile;
    public int currLevel = 1;
    private int reqKeys;

    private List<Vector3> keyPositions = new List<Vector3>();
    private GameObject[] keys;

    // Use this for initialization
    void Start () {
        startingPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
        keys = GameObject.FindGameObjectsWithTag("Key");
        foreach (GameObject k in keys)
        {
            keyPositions.Add(k.transform.position);
        }
        reqKeys = keys.Length;
    }
	
	// Update is called once per frame
	void Update () {

        // Check if player dead
        if (!GameObject.FindWithTag("Player")) {
            spawnPlayer();
            spawnKeys();
        }
	}

    private void spawnKeys() {
        for (int i = 0; i < keys.Length; i++) {
            if (keys[i] == null) {
                GameObject keyClone;
                keyClone = Instantiate(key, keyPositions[i], this.transform.rotation) as GameObject;
                keyClone.transform.SetParent(this.transform);
                keys[i] = keyClone;
            }
        }
        reqKeys = keys.Length;
    }

    private void spawnPlayer() {
        GameObject playerClone;
        playerClone = Instantiate(player, startingPoint, this.transform.rotation) as GameObject;
        playerClone.transform.SetParent(this.transform);
    }

    public void changeLevel() {
        Debug.Log("Endpoint reached");
        string nextSceneName = "Level " + (currLevel + 1).ToString();
        SceneManager.LoadScene(nextSceneName);
    }

    public void keyPickup() {
        reqKeys--;
    }

    public int getReqKeys() {
        return reqKeys;
    }

}
