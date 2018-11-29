using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelManager : MonoBehaviour {
    public GameObject levels;
    private GameObject[] levelTexts;
    private Image[] levelImages;
    private GameObject[] stars;

	void Start () {
        levelTexts = new GameObject[levels.transform.childCount];
        stars = new GameObject[levels.transform.childCount];
        for (int i = 0; i < levels.transform.childCount; i++) {
            GameObject level = levels.transform.GetChild(i).gameObject;
            levelTexts[i] = level.transform.GetChild(1).gameObject;
            stars[i] = level.transform.GetChild(0).gameObject;
        }

        for (int i = 0; i < levels.transform.childCount; i++)
        {
            stars[i].SetActive(GameManager.stars[i]);
            levelTexts[i].GetComponent<Text>().text = "Level " + (i + 1).ToString();
        }
    }

    void Update()
    {

    }
}
