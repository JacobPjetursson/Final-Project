﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float spawnDelay;
    private LevelManager levelManager;
    private Vector2 startPos;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D col;
    private Rigidbody2D rb2d;
    private bool frozenPos;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        startPos = this.transform.position;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.col = GetComponent<BoxCollider2D>();
        this.rb2d = GetComponent<Rigidbody2D>();
        frozenPos = false;
    }

	// Update is called once per frame

	void FixedUpdate () {
        int frozen = (frozenPos) ? 0 : 1;
        float movementSpeedY = speed * Input.GetAxisRaw("Vertical") * Time.deltaTime * frozen;
        float movementSpeedX = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime * frozen;
        transform.Translate(movementSpeedX, movementSpeedY, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Enemy" || tag == "AIEnemy") {
            levelManager.restartLevel();
        }
    }

    public void kill()
    {
        spriteRenderer.enabled = false;
        //col.enabled = false;
        this.transform.position = startPos;
        this.rb2d.Sleep();
        frozenPos = true;
        StartCoroutine(respawn());
    }

    private IEnumerator respawn() {
        yield return new WaitForSeconds(spawnDelay);
        //col.enabled = true;
        spriteRenderer.enabled = true;
        this.rb2d.WakeUp();
        frozenPos = false;
    }
}
