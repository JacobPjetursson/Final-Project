using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour {
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = this.transform.parent.gameObject.GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Destroy(this.gameObject);
            // change level
            levelManager.changeLevel();

        }
    }
}
