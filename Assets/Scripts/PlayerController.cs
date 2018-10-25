using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10f;


    // Use this for initialization
    void Start () {
    }

	// Update is called once per frame
	void FixedUpdate () {
        // movement
        float movementSpeedY = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        float movementSpeedX = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(movementSpeedX, movementSpeedY, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
