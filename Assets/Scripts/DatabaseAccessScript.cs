using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;

public class DatabaseAccessScript : MonoBehaviour {

	public SqliteConnection sql_connection;
	public string DatabaseName;

	void Start(){
		//SqliteConnectionStringBuilder conn_builder = new SqliteConnectionStringBuilder ();
		SqliteConnectionStringBuilder conn_build;
		conn_build = new SqliteConnectionStringBuilder ();
		conn_build.Version = 3;
		conn_build.Uri = "file:" + @DatabaseName;
		//sql_connection = new SqliteConnection ("Uri=file:" + @DatabaseName);
		sql_connection = new SqliteConnection ();
		sql_connection.ConnectionString = conn_build.ToString ();
		sql_connection.Open ();
	}

	// Update is called once per frame
}
