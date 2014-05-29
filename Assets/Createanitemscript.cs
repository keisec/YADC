using UnityEngine;
using System.Collections;

public class Createanitemscript : MonoBehaviour {
	public GameObject item;
	public Texture txture1,txture2;
	// Use this for initialization
	void Start () {
		Vector2 position = new Vector2();
		position.Set (1.5f, 1.5f);
		GenericItemScript.create (position, item, txture1);
		position.Set (2.5f, 1.5f);
		GenericItemScript.create (position, item, txture2);
	}
}
