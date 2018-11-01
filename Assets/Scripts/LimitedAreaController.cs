using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitedAreaController : MonoBehaviour {

    public int initialTimeLeft = 5;
    private int timeLeft;
    private Canvas canvas;
    public Text text;
    private bool playerInside = false;
    private Collider2D col;
    private bool countingDown = false;


    // Use this for initialization
    void Start () {
        col = GetComponent<BoxCollider2D>();
        canvas = GetComponent<Canvas>();
        //text.transform.SetParent(canvas.transform);
        text.text = initialTimeLeft.ToString();
        //text.transform.position = this.transform.position;
        timeLeft = initialTimeLeft;
    }
	
	// Update is called once per frame
	void Update () {
        // FIXME - consider fixing this by moving player instead of destroying it when it touches objects. 
        // That way there is no reason to get game object every tick
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (col.bounds.Contains(player.transform.position)) {
            playerInside = true;
            if (!countingDown) {
                StartCoroutine(countDown());
                countingDown = true;
            }
        } else {
            resetCounter();
        }

	}

    private IEnumerator countDown() {
        while(playerInside) {
            yield return new WaitForSeconds(1);
            if (!playerInside)
                break;
            timeLeft -= 1;
            text.text = timeLeft.ToString();
            if (timeLeft == 0) {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Destroy(player);
            }
        }
        countingDown = false;
    }

    private void resetCounter()
    {
        playerInside = false;
        timeLeft = initialTimeLeft;
        text.text = initialTimeLeft.ToString();
    }
}
