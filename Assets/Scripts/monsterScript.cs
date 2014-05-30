using UnityEngine;
using System.Collections;

public class monsterScript : MonoBehaviour {

    private Vector2 closestHero=new Vector2();
    public float minimumDistanceThreshold = 10;
    private Vector2 movementVector;
    public float walkingSpeed = 3;
	// Update is called once per frame
	void Update () {
        if (networkView.isMine) {
            try {
                closestHero.Set(9999, 9999);
                foreach (GameObject g in mainGuiScript.playerArray) {
                    if (g != null) {
                        if (Vector2.Distance(transform.position, g.transform.position) <
                        Vector2.Distance(transform.position, closestHero)) {
                            closestHero = g.transform.position;
                        }
                    }
                }
                movementVector = closestHero - (Vector2)transform.position;
                if (movementVector.magnitude < minimumDistanceThreshold) {
                    movementVector = movementVector.normalized * walkingSpeed;
                    rigidbody2D.velocity = movementVector;
                } else {
                    rigidbody2D.velocity.Set(0, 0);
                }
            } catch (UnityException e) {
                mainGuiScript.playerArray = GameObject.FindGameObjectsWithTag("Player");
            }
        }
	}
}
