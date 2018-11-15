using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
	//private LevelManager levelManager;
	public GameObject door;
	private SpriteRenderer spriteRenderer;
	private PolygonCollider2D col;

	// Use this for initialization
	void Start () {
		//levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		this.col = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
			spriteRenderer.enabled = false;
			col.enabled = false;
			door.SetActive(false);
        }
    }
	
}
