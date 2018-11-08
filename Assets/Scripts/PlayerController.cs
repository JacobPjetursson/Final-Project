using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
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
            Destroy(this.gameObject);
            levelManager.restartLevel();

        }
    }
}
