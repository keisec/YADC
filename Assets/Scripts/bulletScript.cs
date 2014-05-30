using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
    public float damage=1;
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log("Collision at "+other.transform.position.ToString());
		if(other.gameObject.tag=="Obstacle"){
            try {
                Network.RemoveRPCs(networkView.viewID);
                Network.Destroy(gameObject);
            } catch (UnityException e) {
                Debug.Log("Bullet collision with wall error. " + e.Message);
            }
		}
	}
    /*public float getDamage() { return damage; }
    public void setDamage(float d) { damage = d; }*/
	void Update() {
		if(transform.position.magnitude>200){
            //Network.RemoveRPCsInGroup(0);
            Network.RemoveRPCs(networkView.viewID);
			Network.Destroy(gameObject);
		}
	}
}
