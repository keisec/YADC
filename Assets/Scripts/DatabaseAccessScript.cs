using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;

public class DatabaseAccessScript : MonoBehaviour {

	public SqliteConnection sqlcon;
	public string connectionString;

	DatabaseAccessScript(){
		sqlcon = new SqliteConnection (connectionString);
		sqlcon.Open ();
		Debug.Log ("1");
	}

	// Update is called once per frame
}
