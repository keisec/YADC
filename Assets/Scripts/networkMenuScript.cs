using UnityEngine;
using System.Collections;

public class networkMenuScript : MonoBehaviour {
	public string connectionIP="localhost";
	public int portNumber=8632;
	private bool connected=false;
	private void OnConnectedToServer(){
		//A client has just connected
		Debug.Log ("Connected To Server");
		connected=true;
		Application.LoadLevel("Level1");
	}
	private void OnServerInitialized(){
		//The server has initialized
		connected=true;
		Application.LoadLevel("Level1");
	}
	private void OnDisconnectedFromServer(){
		//The connection has been lost or disconnected
		connected=false;
	}
	void OnFailedToConnect(NetworkConnectionError error) {
		Debug.Log("Could not connect to server: " + error);
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
	private void OnGUI(){
	
		if(!connected){
			connectionIP=GUI.TextField( new Rect(Screen.width/2-100,( 2 * Screen.height / 3)-200,200,50),connectionIP);
			int.TryParse(GUI.TextField(new Rect (Screen.width/2-100,( 2 * Screen.height / 3)-150,200,50),portNumber.ToString()),out portNumber);
			if (GUI.Button (new Rect (Screen.width/2-100,( 2 * Screen.height / 3)-100,200,50),"Connect")){
				Debug.Log("Attepting to connect");
		    	Network.Connect(connectionIP,portNumber);
			}
			if(GUI.Button (new Rect (Screen.width/2-100,( 2 * Screen.height / 3)-50,200,50),"Host"))
		    	Network.InitializeServer(4,portNumber,false);
			if(GUI.Button (new Rect (Screen.width/2-100,( 2 * Screen.height / 3)-50,200,50),"Create Character"))
				Application.LoadLevel("charcreateScene");
		}
      //  else
		//	GUI.Label(new Rect (Screen.width/2-100,( 2 * Screen.height / 3)+ 50,200,50),"Connections: "+Network.connections.Length.ToString());
   }
}
