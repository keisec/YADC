using UnityEngine;
using System.Collections;

public class mainGuiScript : MonoBehaviour {
	public string connectionIP="localhost";
	public int portNumber=8632;
	private bool connected=false;
	private void OnConnectedToServer(){
		//A client has just connected
		Debug.Log ("Connected To Server");
		connected=true;
		//Application.LoadLevel("mainScene");
	}
	private void OnServerInitialized(){
		//The server has initialized
		connected=true;
		//Application.LoadLevel("mainScene");
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
			connectionIP=GUILayout.TextField(connectionIP);
			int.TryParse(GUILayout.TextField(portNumber.ToString()),out portNumber);
			if (GUILayout.Button("Connect")){
				Debug.Log("Attepting to connect");
				Network.Connect(connectionIP,portNumber);
			}
			if(GUILayout.Button("Host"))
				Network.InitializeServer(4,portNumber,false);
		}
		else{
			GUILayout.Label("Connections: "+Network.connections.Length.ToString());
			if(GUILayout.Button("Disconnect")){
				Network.Disconnect();
			}
		}
	}
}
