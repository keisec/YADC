using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log("Collision at "+other.transform.position.ToString());
		if(other.gameObject.tag=="Obstacle"){
			Destroy(gameObject);
		}
	}
	void Update() {
		if(transform.position.magnitude>200){
			Destroy(gameObject);
		}
	}
}
