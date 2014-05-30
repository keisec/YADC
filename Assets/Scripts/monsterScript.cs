using UnityEngine;
using System.Collections;

public class monsterScript : MonoBehaviour {

    private Vector2 closestHero=new Vector2();
    public float minimumDistanceThreshold = 10;
    private Vector2 movementVector;
    public float walkingSpeed = 3;
    public float maxHp = 25;
    public float currentHp = 25;
    public float hitDamage = 2;
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
                Debug.Log("Reconstructing player array " + e.Message);
            }
        }
	}
    void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Collision at " + other.transform.position.ToString());
        if (other.gameObject.tag == "Bullet") {
            try {
                Network.RemoveRPCs(other.gameObject.networkView.viewID);
                Network.Destroy(other.gameObject);
                currentHp -= other.gameObject.GetComponent<bulletScript>().damage;
                if (currentHp <= 0) {
                    Network.RemoveRPCs(networkView.viewID);
                    Network.Destroy(gameObject);
                }
            } catch (UnityException e) {
                Debug.Log("Collision with bullet error = " + e.Message);
            }
        } 
    }
}
