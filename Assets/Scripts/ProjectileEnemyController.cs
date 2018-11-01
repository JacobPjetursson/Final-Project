using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemyController : MonoBehaviour {

    public float speed = 5f;
    public float delay = 4f;
    public Vector2 initialDirection;
    Rigidbody2D rig2D;
    private Vector2 startingPoint;
    private CircleCollider2D col;
    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start () {
        startingPoint = this.transform.position;

        col = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.velocity = initialDirection * new Vector2(speed, speed);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            spriteRenderer.enabled = false;
            col.enabled = false;
            StartCoroutine(respawn());
        }
    }

    private IEnumerator respawn() {
        yield return new WaitForSeconds(delay);
        this.transform.position = startingPoint;
        spriteRenderer.enabled = true;
        col.enabled = true;
    }

}
