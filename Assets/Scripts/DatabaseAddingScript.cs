using UnityEngine;
using System.Collections;
//using Mono.Data.SqliteClient;
using Mono.Data.Sqlite;

public class DatabaseAddingScript : MonoBehaviour {
	
	// Use this for initialization
	void Start(){
	}

	public void AddNewUser(string user,string password){
		gameObject.GetComponent<DatabaseAccessScript>().Do(string.Format ("INSERT INTO utilizator(username,password) "+
		                                                                  "VALUES ('{0}','{1}')",user,password));
	}
}
