using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {
	public string username="username";
	public string pass="password";
	public GameObject dataBase;
	public string eroare="";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void OnGUI(){
		GUI.Label(new Rect(Screen.width/2-100, ( 2 * Screen.height / 3)-50, 200, 50), eroare);
			username=GUI.TextField( new Rect(Screen.width/2-100,( 2 * Screen.height / 3)-200,200,50),username);
		pass=GUI.PasswordField( new Rect(Screen.width/2-100,( 2 * Screen.height / 3)-150,200,50),pass,"*"[0]);

		if (GUI.Button (new Rect (Screen.width/2-100,( 2 * Screen.height / 3)-100,200,50),"Login"))
			{
			if(dataBase.GetComponent<DatabaseInterogationScript>().checkPassword(username,pass))
			{
				Application.LoadLevel("startScene");
			}
			else
			{
				eroare="eroare";
			}

		}
		if (GUI.Button (new Rect (Screen.width/2-100,( 2 * Screen.height / 3)+50,200,50),"Register"))
			{}
		

		}
		//  else
		//	GUI.Label(new Rect (Screen.width/2-100,( 2 * Screen.height / 3)+ 50,200,50),"Connections: "+Network.connections.Length.ToString());
	}

