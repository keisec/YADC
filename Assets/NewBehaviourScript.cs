using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	
	public Texture t;
	public GameObject go;
	
	// Use this for initialization
	void Start () {
		GenericItemScript.create(new Vector2(2.5f,-2.5f),go,t);
		GenericItemScript.create(new Vector2(2.5f,-3.5f),go,t);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
