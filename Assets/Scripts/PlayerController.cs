using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private float spawnDelay = 2;
    private LevelManager levelManager;
    private Vector2 startPos;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        startPos = this.transform.position;
        this.rb2d = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame

	void FixedUpdate () {
        float movementSpeedY = speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        float movementSpeedX = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
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
        this.transform.position = startPos;
        this.rb2d.velocity = Vector2.zero;
    }
}
