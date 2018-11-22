﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyController : MonoBehaviour {
    public float speed;
    public float angleChangingSpeed;
    public float respawnRate;
    public GameObject player;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D col;
    private Vector2 startingPoint;
    private Rigidbody2D r2d;


	void Start () {
        col = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        startingPoint = transform.position;
        respawn();
    }
	
	void FixedUpdate () {
        Vector3 goal = player.transform.position;
        Vector2 direction = (goal - this.transform.position).normalized;

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        r2d.angularVelocity = -angleChangingSpeed * rotateAmount;
        r2d.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle") {
            respawn();
        }
    }

    public void respawn() {
        spriteRenderer.enabled = false;
        col.enabled = false;
        StartCoroutine(spawn());
    }

    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(respawnRate);
        r2d.velocity = Vector2.zero;
        this.transform.position = startingPoint;
        // rotate towards target
        Vector3 current = transform.position;
        var direction = player.transform.position - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

        spriteRenderer.enabled = true;
        col.enabled = true;
    }
}
