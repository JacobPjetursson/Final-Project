using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    float movementSpeedY;
    float movementSpeedX;
    Rigidbody2D rig2D;

    // Use this for initialization
    void Start () {
        rig2D = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
    
	void FixedUpdate () {

        movementSpeedY = speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        movementSpeedX = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        transform.Translate(movementSpeedX, movementSpeedY, 0);
        
        transform.rotation = Quaternion.identity;
    }

    // private void OnCollisionEnter2D(Collision2D col) {
    //     Collider2D collision = col.collider;
        
    //     if (col.gameObject.tag == "Obstacle") {
    //         Vector3 contactPoint = col.contacts[0].point;
    //         Vector3 center = collision.bounds.center;

    //         bool right = contactPoint.x > center.x;
    //         bool top = contactPoint.y > center.y;
    //         bool left = contactPoint.x < center.x;
    //         bool bottom = contactPoint.y < center.y;

    //         if(right || left) {
    //             movementSpeedX = 0;
    //         }
    //         else if(top || bottom) {
    //             movementSpeedY = 0;
    //         }
    //     }
    // }

    
}
