using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {

	public float speed;
    public Vector2 initialDirection;
    Rigidbody2D rig2D;
    private Vector2 initialPos;
    private float height;

    // Use this for initialization
    void Start () {
        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.velocity = initialDirection * new Vector2(speed, speed);
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        initialPos = this.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y >= initialPos.y + (height/2))  {
            respawn();
		}
        else if (this.transform.position.y <= initialPos.y) {
            respawn();
		}

	}

    private void respawn() {
        initialDirection *= -1;
        rig2D.velocity = initialDirection * new Vector2(speed, speed);
    }
}

