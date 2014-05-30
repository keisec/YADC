using UnityEngine;
using System.Collections;
//using Mono.Data.SqliteClient;
using Mono.Data.Sqlite;

public class DatabaseAddingScript : MonoBehaviour {

	// Use this for initialization
	void Start(){
		Debug.Log ("2");
	}
	public void AddNewUser(string user,string password){
		SqliteCommand comm = new SqliteCommand ();
		comm.Connection = gameObject.GetComponent<DatabaseAccessScript> ().sql_connection;
		comm.CommandText = "INSERT INTO utilizator(username,password) VALUES (" +
						user + "," + password + ")";
		comm.ExecuteNonQuery ();
	}
}
