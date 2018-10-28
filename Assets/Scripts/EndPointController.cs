using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour {
    private LevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    private Color red = new Color(255, 0, 0);
    private Color green = new Color(0, 255, 0);

    private bool open;

	// Use this for initialization
	void Start () {
        levelManager = this.transform.parent.gameObject.GetComponent<LevelManager>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        open = levelManager.getReqKeys() == 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (open) {
            spriteRenderer.color = green;
        } else {
            spriteRenderer.color = red;
        }

        open = levelManager.getReqKeys() == 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && open) {
            Destroy(this.gameObject);
            // change level
            levelManager.changeLevel();

        }
    }
}
