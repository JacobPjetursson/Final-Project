using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private LevelManager levelManager;
    private Rigidbody2D rb2d;
    private bool faceRight = true;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        this.rb2d = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame

	void FixedUpdate () {
        float movementSpeedY = speed * Input.GetAxisRaw("Vertical");
        float movementSpeedX = speed * Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movementSpeedX, movementSpeedY);

        if (rb2d.velocity.x < 0 && faceRight) {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            faceRight = false;

        } else if (rb2d.velocity.x > 0 && !faceRight) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            faceRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Enemy") {
            levelManager.playerDied();
        }
    }
}
