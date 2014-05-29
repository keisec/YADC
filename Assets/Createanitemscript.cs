using UnityEngine;
using System.Collections;

public class Createanitemscript : MonoBehaviour {
	public GameObject chest;
	// Use this for initialization
	void Start () {
		Vector2 position = new Vector2(1.5f,1.5f);
		Quaternion rotation = new Quaternion ();
		Instantiate (chest, position, rotation);
	}
}
