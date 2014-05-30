using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;

public class DatabaseAccessScript : MonoBehaviour {

	public SqliteConnection sqlcon;
	public string DatabaseName;

	void Start(){
		//SqliteConnectionStringBuilder conn_builder = new SqliteConnectionStringBuilder ();

		sqlcon = new SqliteConnection ("Uri="+@DatabaseName);
		sqlcon.Open ();	
		SqliteCommand sqlcomm = new SqliteCommand ("Select username,password from utilizator;",sqlcon);
		Debug.Log ("1");
		SqliteDataReader sdr = sqlcomm.ExecuteReader ();
		while (sdr.Read()) {
			Debug.Log(sdr.GetString(1)+sdr.GetString(2));
		}
	}

	// Update is called once per frame
}
