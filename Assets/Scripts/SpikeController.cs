using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {

	public float speed;
    public Vector2 initialDir;
    Rigidbody2D rig2D;
    private Vector2 initialPos;
    private Vector3 boundsSize;

    // Use this for initialization
    void Start () {
        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.velocity = initialDir * new Vector2(speed, speed);
        boundsSize = GetComponent<PolygonCollider2D>().bounds.size;
        initialPos = this.transform.position;

    }
	
	void Update () {
        if (initialDir.x == 0 && this.transform.position.y >= initialPos.y + boundsSize.y)  {
            respawn();
		}
        else if (initialDir.x == 0 && this.transform.position.y <= initialPos.y) {
            respawn();
		}
        else if (initialDir.y == 0 && this.transform.position.x >= initialPos.x + boundsSize.x) {
            respawn();
        }
        else if (initialDir.y == 0 && this.transform.position.x <= initialPos.x) {
            respawn();
        }

	}

    private void respawn() {
        initialDir *= -1;
        rig2D.velocity = initialDir * new Vector2(speed, speed);
    }
}

