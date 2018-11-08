using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private Vector2 startingPoint;
    public GameObject player;
    public GameObject endPoint;
    public GameObject key;
    public GameObject ai;
    public int currLevel = 1;
    private int reqKeys;

    private List<Vector3> keyPositions = new List<Vector3>();
    private List<Vector3> aiPositions = new List<Vector3>();
    private GameObject[] keys;
    private GameObject[] AIs;

    // Use this for initialization
    void Start () {
        startingPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
        keys = GameObject.FindGameObjectsWithTag("Key");
        foreach (GameObject k in keys)
        {
            keyPositions.Add(k.transform.position);
        }
        reqKeys = keys.Length;

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
        spawnKeys();
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

    public void keyPickup() {
        reqKeys--;
    }

    public int getReqKeys() {
        return reqKeys;
    }

}
