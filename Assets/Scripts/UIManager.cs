using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;

	private bool isDead;

	// Use this for initialization
	void Start () {
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead) {
			showPaused();
		}
	}

	public void showPaused(){
        foreach(GameObject g in pauseObjects){
            g.SetActive(true);
        }
    }

	public void hidePaused(){
        foreach(GameObject g in pauseObjects){
            g.SetActive(false);
        }
    }
}
