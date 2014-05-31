using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(200,200,100,50),"Play!"))
		{
			Debug.Log("i'm gona play!");
			Application.LoadLevel(1);
		}
	}


}
