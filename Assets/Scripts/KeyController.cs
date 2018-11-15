using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
	//private LevelManager levelManager;
	public GameObject door;
	private SpriteRenderer spriteRenderer;
	private PolygonCollider2D col;
	public float doorSpeed;
    public Vector2 doorInitialDirection;
    Rigidbody2D rig2D;
	private Vector2 doorPos;
	private float doorHeight;
	private bool open;
	

	// Use this for initialization
	void Start () {
		//levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		this.col = GetComponent<PolygonCollider2D>();
		
		rig2D = door.GetComponent<Rigidbody2D>();
		doorPos = door.transform.position;
		doorHeight = door.GetComponent<SpriteRenderer>().bounds.size.y;
		open = false;

	}
	
	// Update is called once per frame
	void Update () {
        if ((door.transform.position.y > doorPos.y + doorHeight) && !open) {
            rig2D.velocity = Vector2.zero;
            open = true;
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
			spriteRenderer.enabled = false;
			col.enabled = false;
            rig2D.velocity = doorInitialDirection * new Vector2(doorSpeed, doorSpeed);
        }
    }

    public void respawn() {
        spriteRenderer.enabled = true;
        col.enabled = true;
        door.transform.position = doorPos;
        open = false;

    }

}
