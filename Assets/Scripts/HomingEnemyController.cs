using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyController : MonoBehaviour {
    public float speed = 4f;
    public float respawnRate;
    public GameObject player;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D col;
    private Vector2 startingPoint;
    private Rigidbody2D r2d;


	// Use this for initialization
	void Start () {
        col = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        startingPoint = transform.position;
        respawn();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 goal = player.transform.position;
        Vector2 direction = (goal - this.transform.position).normalized;
        // Add force
        r2d.velocity = (direction * speed);
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
        spriteRenderer.enabled = true;
        col.enabled = true;
    }
}
