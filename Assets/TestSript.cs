using UnityEngine;
using System.Collections;

public class TestSript : MonoBehaviour {
	public GameObject obj;
	// Use this for initializatio
	
	void OnGUI () {
		GUI.Box(new Rect(10,10,100,70), "Loader Menu");
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			//Network.Disconnect();
			Debug.Log ("3");
		}
		
		// Make the second button.
	}
	
	void OnDisconnectedFromServer(NetworkDisconnection info) {
		if (Network.isServer)
			Debug.Log("Local server connection disconnected");
		else
			if (info == NetworkDisconnection.LostConnection)
				Debug.Log("Lost connection to the server");
		else
			Debug.Log("Successfully diconnected from the server");
	}
	
	// Update is called once per frame
	
}
