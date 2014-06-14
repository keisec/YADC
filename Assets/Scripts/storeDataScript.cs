using UnityEngine;
using System.Collections;

public class storeDataScript : MonoBehaviour {

	// Use this for initialization
	
	public string username;
	public bool server;
	public string connectionIP;
	public int portNumber;
	
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
