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
        gameSave = LoadGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitGame() {
        SaveGame(gameSave);
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Level " + GameSave.maxLevel.ToString());
    }

    public void SaveGame(GameSave gameSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save_game.dat");
        bf.Serialize(file, gameSave);
        file.Close();
    }

    public GameSave LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save_game.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save_game.dat", FileMode.Open);
            GameSave gs = (GameSave)bf.Deserialize(file);
            file.Close();
            return gs;
        }
        return new GameSave();
    }

    public void LoadHowTo() {
        SceneManager.LoadScene("HowTo");
    }
}
