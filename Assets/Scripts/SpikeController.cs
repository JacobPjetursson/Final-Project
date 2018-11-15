using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {

	public float speed = 5f;
    public Vector2 initialDirection;
    Rigidbody2D rig2D;

    // Use this for initialization
    void Start () {

        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.velocity = initialDirection * new Vector2(speed, speed);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            respawn();
        }
    }

    private void respawn() {
        initialDirection *= -1;
        //rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.velocity = initialDirection * new Vector2(speed, speed);
    }
}

