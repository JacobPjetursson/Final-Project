using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private GameSave gameSave;

	// Use this for initialization
	void Start () {
        GameManager.LoadGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitGame() {
        GameManager.SaveGame();
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Level " + GameManager.maxLevel.ToString());
    }

    public void LoadHowTo() {
        SceneManager.LoadScene("HowTo");
    }
}
