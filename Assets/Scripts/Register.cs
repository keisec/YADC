using UnityEngine;
using System.Collections;

public class Register : MonoBehaviour {

	public string username="username";
	public string pass="password";
	public string confpass="password";
	public GameObject dataBase;
	public string eroare1="eroare: username-ul a fost deja inregistrat";
	public string eroare2="eroare: username sau parola prea scurte";
	public string eroare3="eroare: parolele nu se potrivesc";
	public bool exista=true;
	private string errorMessage="";
	public int lungimeMinParolaUsername=5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnGUI(){
		GUI.Label(new Rect(Screen.width/2-100, ( 2 * Screen.height / 3)-50, 200, 50), errorMessage);
		GUI.Label(new Rect(Screen.width/2-150, ( 2 * Screen.height / 3)-200, 100, 30), "Username");
		GUI.Label(new Rect(Screen.width/2-150, ( 2 * Screen.height / 3)-150, 100, 30), "Password");
		GUI.Label(new Rect(Screen.width/2-150, ( 2 * Screen.height / 3)-100, 100, 40), "Confirm Password");
		username=GUI.TextField( new Rect(Screen.width/2-50,( 2 * Screen.height / 3)-200,200,50),username);
		pass=GUI.PasswordField( new Rect(Screen.width/2-50,( 2 * Screen.height / 3)-150,200,50),pass,"*"[0]);
		confpass=GUI.PasswordField( new Rect(Screen.width/2-50,( 2 * Screen.height / 3)-100,200,50),confpass,"*"[0]);
		
		if (GUI.Button (new Rect (Screen.width/2-100,( 2 * Screen.height / 3),200,50),"Submit"))
		{
			if(true){ //existenta username in baza de date modifica "true" cu scriptul de sql
				exista=true;
			}
			if(exista==false)
				if(username.Length>=lungimeMinParolaUsername&&pass.Length>=lungimeMinParolaUsername)
					if(pass.Equals(confpass))
							{
					//insert
					Application.LoadLevel("startScene");
				}
					else{
						errorMessage=eroare3;
						}
				else{
				errorMessage=eroare2;	
				}
			else
			{
			errorMessage=eroare1;
			}

			exista=false;
		}
		if (GUI.Button (new Rect (Screen.width/2-100,( 2 * Screen.height / 3)+100,200,50),"Back"))
		{
			Application.LoadLevel("loginScene");
		}
		
		
	}
	//  else
	//	GUI.Label(new Rect (Screen.width/2-100,( 2 * Screen.height / 3)+ 50,200,50),"Connections: "+Network.connections.Length.ToString());
}
