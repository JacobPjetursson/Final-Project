using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    private Rigidbody2D rb2D;


    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        // movement
        float movementSpeedY = speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        float movementSpeedX = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        transform.Translate(movementSpeedX, movementSpeedY, 0);
        /*
        float movementSpeedY = speed * Input.GetAxisRaw("Vertical");
        float movementSpeedX = speed * Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(movementSpeedX, movementSpeedY);
        rb2D.AddForce(movement * speed);
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
