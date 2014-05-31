using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;

public class DatabaseAccessScript : MonoBehaviour {

	//SqliteConnection sql_connection;
	string connectionString;
	public string DatabaseName;

	void Start(){
		//SqliteConnectionStringBuilder conn_builder = new SqliteConnectionStringBuilder ();
		SqliteConnectionStringBuilder conn_build;
		conn_build = new SqliteConnectionStringBuilder ();
		conn_build.Version = 3;
		conn_build.Uri = "file:" + @DatabaseName;
		connectionString = conn_build.ToString ();
		//sql_connection = new SqliteConnection ("Uri=file:" + @DatabaseName);
		//sql_connection = new SqliteConnection ();
		//sql_connection.ConnectionString = conn_build.ToString ();
	}
	public void Do(string command){
		using (SqliteConnection sql_connection=new SqliteConnection(connectionString)) {
			SqliteCommand comm = new SqliteCommand (command, sql_connection);
			sql_connection.Open ();
			try {
				comm.ExecuteNonQuery ();
			} catch (SqliteException e) {
				Debug.Log (e.ToString ());
			}
		}
	}

	public DataSet Get(string command){
		DataSet dataSet = new DataSet ();
		using (SqliteConnection sql_connection=new SqliteConnection(connectionString)) {
			SqliteDataAdapter slda=new SqliteDataAdapter(command,sql_connection);
			sql_connection.Open();
			slda.Fill(dataSet);
			sql_connection.Close();
		}
		return dataSet;
	}

	// Update is called once per frame
}
