using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log("Collision at "+other.transform.position.ToString());
		if(other.gameObject.tag=="Wall"){
			Destroy(gameObject);
		}
	}
}
